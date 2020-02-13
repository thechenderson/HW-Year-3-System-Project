#include "mbed.h"
#include "MCP23017.h"
#include "WattBob_TextLCD.h"
#include "cmd_io.h"
#include "globals.h"
#include "TCS3472_I2C.h"
#include "VL6180.h"
#include "stdint.h"
//*********************************************************************************
//Creating the system objects 
DigitalOut myled(LED1);  
PwmOut servo_0(p26);
PwmOut servo_1(p25);
PwmOut servo_2(p24);
PwmOut servo_3(p23);
PwmOut servo_4(p22);
PwmOut servo_5(p21);

#define     BACK_LIGHT_ON(INTERFACE)    INTERFACE->write_bit(1,BL_BIT)
#define     BACK_LIGHT_OFF(INTERFACE)   INTERFACE->write_bit(0,BL_BIT)

#define IDENTIFICATIONMODEL_ID 0x0000

MCP23017            *par_port;
WattBob_TextLCD     *lcd;

VL6180  TOF_sensor(p28, p27);//Setting up the distance sensor and its connected pins
TCS3472_I2C rgb_sensor(p9, p10); //Setting up the colour sensor and its conected pins

Serial      pc(USBTX, USBRX);//COM port for communication between PC and board

// Defined GLOBAL variables and structures
CMD_STRUCT         ext_cmd;     // structure to hold command data
STAT_STRUCT        ext_stat;    // structure to hold status reply

uint32_t   last_servo;          // store for last servo number

//******************************************************************************************

void init_sys(void) {//Initialsisation of the system for Maintainance Mode

    par_port = new MCP23017(p9, p10, 0x40);
    lcd = new WattBob_TextLCD(par_port);

    par_port->write_bit(1,BL_BIT);   // turn LCD backlight ON
    lcd->cls();
    lcd->locate(0,0);
    lcd->printf("Maintainance");
    
    servo_0.period(0.020);    // servo requires a 20ms period, common for all 5 servo objects
    last_servo = SERVO_UNKNOWN; 
    pc.baud(115200);

    return;
}

uint32_t ServoMove(CMD_STRUCT *command){
    int32_t pulse_width;
    command->nos_data = 0;                   // no data to be returned
    //
    // check that parameters are OK
    //
            if (command->nos_params != 2) {          // check for 2 parameters
                command->result_status = CMD_BAD_NUMBER_OF_PARAMETERS;
                //break;
            }
            if (command->param[0] > MAX_SERVO_NUMBER ) {       // check servo number
                command->result_status = CMD_BAD_SERVO_NUMBER;
                //break;
            }
            if ((command->param[1] < MIN_SERVO_ANGLE) ||
                (command->param[1] > MAX_SERVO_ANGLE) ) { 
                command->result_status = CMD_BAD_SERVO_VALUE;
                //break;
            }
            pulse_width = 1000 + (command->param[1] * 1000) / MAX_SERVO_ANGLE;  // convert angle to pulse width
    //
    // implement servo move to all 5 servos
    //
            switch (command->param[0]) {
                case 0 : servo_0.pulsewidth_us(pulse_width); break;
                case 1 : servo_1.pulsewidth_us(pulse_width); break;
                case 2 : servo_2.pulsewidth_us(pulse_width); break;
                case 3 : servo_3.pulsewidth_us(pulse_width); break;
                case 4 : servo_4.pulsewidth_us(pulse_width); break;
                case 5 : servo_5.pulsewidth_us(pulse_width); break;
            }
            last_servo = command->param[0];
        return last_servo;
}

void ServoRead(CMD_STRUCT *command, uint32_t last_servo){
    command->nos_data = 1;                   // no data to be returned
            command->result_data[0] = last_servo;
}

int ColourSensor() {
    
    int rgb_readings[4];
        
    par_port = new MCP23017(p9, p10, 0x40);
    par_port->config(0x0F00, 0x0F00, 0x0F00);           // configure MCP23017 chip on WattBob

    lcd = new WattBob_TextLCD(par_port);

    BACK_LIGHT_ON(par_port);
    lcd->printf("Colour sensor \n");
    
    rgb_sensor.enablePowerAndRGBC();
    rgb_sensor.setIntegrationTime(100);
    
    myled = 1;
    
    rgb_sensor.getAllColors(rgb_readings);
    //pc.printf("red  %d,  green: %d,  blue: %d,  clear: %d\r\n",rgb_readings[0], rgb_readings[1], rgb_readings[2],rgb_readings[3]);
    lcd->cls(); lcd->locate(0,0);
    lcd->printf("clear: %d",rgb_readings[0]);
    pc.printf("%d\r\n",rgb_readings[0]);
    wait(2);
    lcd->cls(); lcd->locate(0,0);
    lcd->printf("red: %d",rgb_readings[1]);
    pc.printf("%d\r\n",rgb_readings[1]);
    wait(2);
    lcd->cls(); lcd->locate(0,0);
    lcd->printf("green:  %d",rgb_readings[2]);
    pc.printf("%d\r\n",rgb_readings[2]);
    wait(2);
    lcd->cls(); lcd->locate(0,0);
    lcd->printf("blue: %d",rgb_readings[3]);
    pc.printf("%d\r\n",rgb_readings[3]);
    wait(2);
}

int DistanceSensor()
{
    uint8_t dist;
    
    TOF_sensor.VL6180_Init();
    par_port = new MCP23017(p9, p10, 0x40);
    par_port->config(0x0F00, 0x0F00, 0x0F00);           // configure MCP23017 chip on WattBob

    lcd = new WattBob_TextLCD(par_port);

    BACK_LIGHT_ON(par_port);
    lcd->printf("TOF sensor");
    wait(3);
    lcd->cls(); lcd->locate(0,0);

    for(;;) {
        dist = TOF_sensor.getDistance();
        lcd->printf("d=%d", dist);
        wait(0.5);
        lcd->cls(); lcd->locate(0,0);
    }
}

uint32_t Process_Command(CMD_STRUCT *command){
    switch (command->cmd_code) {
        case SERVO_CMD :
            uint32_t last_servo = ServoMove(&ext_cmd);
            break;
        case READ_CMD :
            ServoRead(&ext_cmd,last_servo);
            break;
        case COLOUR_CMD:
            ColourSensor();
            break;
        case DISTANCE_CMD:
            DistanceSensor();
            break;
        default:
            command->nos_data = 0;                   // no data to be returned
            command->result_status = CMD_BAD_SERVO_VALUE;
            break;
        }
    return OK;
}

int main() {

    init_sys();
    FOREVER {
        get_cmd(&ext_cmd);
    //
    // Check status of read command activity and return an error status if there was a problem
    // If there is a problem, then return status code only and wait for next command.
    //
        if (ext_cmd.result_status != OK){
            send_status(ext_cmd.result_status);
            continue;
        }
    //
    // Parse command and return an error staus if there is a problem
    // If there is a problem, then return status code only and wait for next command.
    //
        parse_cmd(&ext_cmd);
        lcd->locate(1,0); lcd->printf(ext_cmd.cmd_str);
        if ((ext_cmd.result_status != OK) && (ext_cmd.cmd_code != TEXT_CMD)){
            lcd->locate(1,0); lcd->printf("parse : error");
            send_status(ext_cmd.result_status);
            continue;
        }
    //
    // Execute command and return an error staus if there is a problem
    //
        Process_Command(&ext_cmd);
        reply_to_cmd(&ext_cmd);
    }
}




