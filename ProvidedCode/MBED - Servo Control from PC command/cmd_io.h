//
// cmd_io.h : Common definitions
// ========
//
#include    "mbed.h"

#ifndef     CMD_IO_H            // used to prevent 'cmd_io.h' being
#define     CMD_IO_H            // included multiple time during a compilation
//
// Constants
//
#define     CMD_STR_BUFFER_SZ       100
#define     MAX_SERVO_NUMBER          5
#define     MIN_SERVO_ANGLE           0
#define     MAX_SERVO_ANGLE          90
//
// Use 'enum' construct to create list of return codes.
// Each entry will be defined as 1 more than the previous entry
//
enum {
    OK = 0,                 // should start at 0 by default but set to 0 to be safe
    CMD_BAD_CHARACTER, 
    CMD_BAD_NUMBER_OF_PARAMETERS, 
    CMD_BAD_SERVO_NUMBER,
    CMD_BAD_SERVO_VALUE,
    CMD_BAD_SERVO_SPEED_VALUE,
    CMD_NO_TERMINATOR,
    CMD_UNKNOWN_COMMAND
};

//
// command set
//
#define     SERVO_CMD      's'
#define     TEXT_CMD       'T'
#define     READ_CMD       'r'
//
// Misc defines
//
#define     SERVO_UNKNOWN           9999

//************************************************************************
// definition of a structure to hold a PC command, its parameteres
// its results and status.
//
typedef struct {
    char    cmd_str[CMD_STR_BUFFER_SZ];
    uint32_t    char_cnt;            // number of characters in string
    uint32_t    cmd_code;            // extracted command code
    uint32_t    param[4];            // command parameters
    uint32_t    nos_params;          // number of parameters
    uint32_t    result_data[3];      // data resulting from command execution
    uint32_t    nos_data;            // number of data items
    uint32_t    result_status;       // status
} CMD_STRUCT;

//************************************************************************
// definition of a structure to hold complete status return
//
typedef struct {
    uint8_t   status;
    union {     // union allows one data item to be viewed in different ways
        uint8_t  byte[4];
        int16_t  value16[2];
        int32_t  value32;
    } parameter;
    uint8_t  result;
} STAT_STRUCT;

//************************************************************************
// function prototypes : list of functions in file 'cmd_io.cpp"
//
uint32_t    get_cmd(CMD_STRUCT *command);
void        init_sys(void);
uint32_t    parse_cmd(CMD_STRUCT *command);
void        reply_to_cmd(CMD_STRUCT *command);
void        send_status(uint32_t  value);
void        send_data(CMD_STRUCT *command);
uint32_t process_cmd(CMD_STRUCT *command);

#endif      // end of multiple include protection facility
