#include "mbed.h"
#include "stdint.h"
#include "MCP23017.h"
#include "WattBob_TextLCD.h"
#include "VL6180.h"

//Hyperterminal configuration
//9600 bauds, 8-bit data, no parity

//VL6180X defines


#define IDENTIFICATIONMODEL_ID 0x0000


Serial    pc(USBTX, USBRX);
VL6180  TOF_sensor(p28, p27);

DigitalOut myled(LED1);

#define     BACK_LIGHT_ON(INTERFACE)    INTERFACE->write_bit(1,BL_BIT)
#define     BACK_LIGHT_OFF(INTERFACE)   INTERFACE->write_bit(0,BL_BIT)

MCP23017            *par_port;
WattBob_TextLCD     *lcd;

int main()
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
