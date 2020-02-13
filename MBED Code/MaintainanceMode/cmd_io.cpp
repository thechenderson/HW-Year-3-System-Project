//
// cmd_io.cpp : library of routines to communicate with virtual COM port
// ==========
//
#include    "mbed.h"
#include    "cmd_io.h"
#include    "globals.h"

//************************************************************************
//
// get_cmd - read a command string from the serial port
// =======
// 
// Method
//      1. Read string of data until a Newline character
//            string is passed as the parameter
//      2. return a sting through the pointer and a count of the number of characters
//
// Notes
//
uint32_t get_cmd(CMD_STRUCT *command)
{
char   ch;
uint8_t  i;
//
// read string and use newline as terminator
//
    for (i= 0  ; i < CMD_STR_BUFFER_SZ ; i++) {
        ch = pc.getc();
        if (ch == '\r') {
            continue;
        }
        command->cmd_str[i] = ch;
        if (ch == '\n') {
            command->cmd_str[i] = '\0';
            break;
        }
    }
    command->char_cnt = i;    // record character count
    command->result_status = OK;
    return 0;
}

//************************************************************************
//
// parse_cmd - split command into its component parts
// =========
// 
// Method
//      1. first character is the command code
//      2. subsequent character define a set of parameters
//
//        String is located in the CMD_STRUCT and the resulting
//        data is returned to the same structure.
//
// Notes
//
uint32_t parse_cmd(CMD_STRUCT *command)
{
uint8_t  param_cnt, i, state;
uint16_t tmp;

    command->cmd_code = command->cmd_str[0];
    param_cnt = 0;
    tmp = 0;
    state = 0;
    for (i=1 ; i < CMD_STR_BUFFER_SZ ; i++) {    // step through characters
        if (command->cmd_str[i] == '\0') {
            if (state == 1) {     // count paramter that is terminated by NEWLINE
                command->param[param_cnt] = tmp;
                param_cnt++;
            }
            command->nos_params = param_cnt;
            return OK;
        }
        if ((command->cmd_str[i] == ' ') && (state == 0)) {        // skip spaces
            continue;        
        }
        if ((command->cmd_str[i] == ' ') && (state == 1)) {        // skip spaces
            state = 0;
            command->param[param_cnt] = tmp;
            param_cnt++;
            tmp = 0;
            continue;        
        }
        state = 1;
        if ((command->cmd_str[i] >= '0') && (command->cmd_str[i] <= '9')) {
            tmp = (tmp * 10) + (command->cmd_str[i] - '0');
        } else {
            command->param[param_cnt] = tmp;
            return CMD_BAD_CHARACTER;
        }
    }
    return CMD_NO_TERMINATOR;
}

//************************************************************************
//
// reply_to_cmd - return data and status info
// ============
// 
// Method
//
// Notes
//
void reply_to_cmd(CMD_STRUCT *command)
{
    send_status(command->result_status);
    if ((command->result_status == OK) && (command->nos_data > 0)) {
        send_data(command);
    }
}

//************************************************************************
//
// send_status - command status
// ===========
//
// Notes
//        return status value as a positive interger in a string format
//        with a terminating newline character.
//
void send_status(uint32_t  value)
{
    pc.printf("%d\n", value);
    return;
}

//************************************************************************
//
// send_data - send data appropriate to the command 
// =========
// 
// Method
//
// Notes
//
void send_data(CMD_STRUCT *command)
{
char buffer[80];
uint8_t i;
//
// create data string
//
    if (command->nos_data == 1) {
        sprintf(buffer, "%u\n", (int)command->result_data[0]);
    }
    if (command->nos_data == 2) {
        sprintf(buffer, "%u %u\n", (int)command->result_data[0], (int)command->result_data[1]);
    }
//
// send string
//
    for (i = 0 ; i < 40 ; i++) {
        if (buffer[i] == '\0') {    // do not send NULL character
            return;
        }
        pc.putc(buffer[i]);
    }
    return;
}
