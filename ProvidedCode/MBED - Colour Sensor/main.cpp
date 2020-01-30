#include "mbed.h"
#include "MCP23017.h"
#include "WattBob_TextLCD.h"
#include "TCS3472_I2C.h"

DigitalOut myled(LED1);

#define     BACK_LIGHT_ON(INTERFACE)    INTERFACE->write_bit(1,BL_BIT)
#define     BACK_LIGHT_OFF(INTERFACE)   INTERFACE->write_bit(0,BL_BIT)

MCP23017            *par_port;
WattBob_TextLCD     *lcd;

TCS3472_I2C rgb_sensor(p9, p10);

Serial      pc(USBTX, USBRX);  // default 9600 baud

int main() {
    
int rgb_readings[4];
    
    par_port = new MCP23017(p9, p10, 0x40);
    par_port->config(0x0F00, 0x0F00, 0x0F00);           // configure MCP23017 chip on WattBob

    lcd = new WattBob_TextLCD(par_port);

    BACK_LIGHT_ON(par_port);
    lcd->printf("Colour sensor \n");
    
    rgb_sensor.enablePowerAndRGBC();
    rgb_sensor.setIntegrationTime(100);
    
    myled = 1;
    
    for (int i = 0 ; i < 10 ; i++) {
        rgb_sensor.getAllColors(rgb_readings);
        //pc.printf("red  %d,  green: %d,  blue: %d,  clear: %d\r\n",rgb_readings[0], rgb_readings[1], rgb_readings[2],rgb_readings[3]);
        lcd->cls(); lcd->locate(0,0);
        lcd->printf("clear: %d",rgb_readings[0], rgb_readings[1], rgb_readings[2],rgb_readings[3]);
        wait(2);
        lcd->cls(); lcd->locate(0,0);
        lcd->printf("red: %d",rgb_readings[1]);
        wait(2);
        lcd->cls(); lcd->locate(0,0);
        lcd->printf("green:  %d",rgb_readings[2]);
        wait(2);
        lcd->cls(); lcd->locate(0,0);
        lcd->printf("blue: %d",rgb_readings[3]);
        wait(2);
    }
}
