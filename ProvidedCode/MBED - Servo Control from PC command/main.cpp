//
// COM_test : program to communicate via a COM port to a PC/laptop
// ========
//
// Description
//      Program to receive ASCII format commands through a virtual COM port and
//      after executing the command return some data (optional, depending on
//      the command) and a status value.
//      The program understands two possible commands :
//          "s i j"     : move servo 'i (0 to 5) to postion 'j' (0 to 90)
//          "r"         : read the 'i' parameter of the last "s" command
//
// Version : 1.0
// Author : Jim Herd
// Date : 5th Oct 2011
//
#include "mbed.h"
#include "MCP23017.h"
#include "WattBob_TextLCD.h"
#include "cmd_io.h"
#include "globals.h"

//******************************************************************************
// declare set of system objects
//
// 1. one of the blue LEDs on the MBED chip carrier
//
DigitalOut myled(LED1);     
//
// 2. five servo outputs
//
PwmOut servo_0(p26);
PwmOut servo_1(p25);
PwmOut servo_2(p24);
PwmOut servo_3(p23);
PwmOut servo_4(p22);
PwmOut servo_5(p21);
//
// 3. objects necessary to use the 2*16 character MBED display
//
MCP23017            *par_port;
WattBob_TextLCD     *lcd;
//
// 4. Virtual COM port over USB link to laptop/PC
//
Serial      pc(USBTX, USBRX);

//******************************************************************************
// Defined GLOBAL variables and structures
//
CMD_STRUCT         ext_cmd;     // structure to hold command data
STAT_STRUCT        ext_stat;    // structure to hold status reply

uint32_t   last_servo;          // store for last servo number

//************************************************************************
//************************************************************************
// init_sys : initialise the system
// ========
//
// 1. Configure 2*16 character display
// 2. Print "COM test" string
// 3. initialise relevant global variables
// 4. set COM port baud rate to 19200 bits per second
//
void init_sys(void) {

    par_port = new MCP23017(p9, p10, 0x40);
    lcd = new WattBob_TextLCD(par_port);

    par_port->write_bit(1,BL_BIT);   // turn LCD backlight ON
    lcd->cls();
    lcd->locate(0,0);
    lcd->printf("COM Test");
    
    servo_0.period(0.020);    // servo requires a 20ms period, common for all 5 servo objects
    last_servo = SERVO_UNKNOWN; 
    pc.baud(115200);

    return;
}              // end init_sys

//************************************************************************
// process_cmd : decode and execute command
// ===========
//
uint32_t process_cmd(CMD_STRUCT *command)
{
int32_t pulse_width;

    switch (command->cmd_code) {
//
// move a servo
//
        case SERVO_CMD :
            command->nos_data = 0;                   // no data to be returned
    //
    // check that parameters are OK
    //
            if (command->nos_params != 2) {          // check for 2 parameters
                command->result_status = CMD_BAD_NUMBER_OF_PARAMETERS;
                break;
            }
            if (command->param[0] > MAX_SERVO_NUMBER ) {       // check servo number
                command->result_status = CMD_BAD_SERVO_NUMBER;
                break;
            }
            if ((command->param[1] < MIN_SERVO_ANGLE) ||
                (command->param[1] > MAX_SERVO_ANGLE) ) { 
                command->result_status = CMD_BAD_SERVO_VALUE;
                break;
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
            break;
//
// return last servo number
//
        case READ_CMD :
            command->nos_data = 1;                   // no data to be returned
            command->result_data[0] = last_servo;
            break;
//
// catch any problems
//            
        default:
            command->nos_data = 0;                   // no data to be returned
            command->result_status = CMD_BAD_SERVO_VALUE;
            break;
    }
    return  OK;
}

//************************************************************************
//************************************************************************
//
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
        process_cmd(&ext_cmd);
        reply_to_cmd(&ext_cmd);
    }
}
