// CONFIG1L
#pragma config WDTEN = OFF      // Watchdog Timer (Disabled - Controlled by SWDTEN bit)
#pragma config PLLDIV = 3       // PLL Prescaler Selection (Divide by 3 (12 MHz oscillator input))
#pragma config CFGPLLEN = ON   // PLL Enable Configuration Bit (PLL Disabled)
#pragma config STVREN = ON      // Stack Overflow/Underflow Reset (Enabled)
#pragma config XINST = OFF       // Extended Instruction Set (Enabled)

// CONFIG1H
#pragma config CPUDIV = OSC1    // CPU System Clock Postscaler (No CPU system clock divide)
#pragma config CP0 = OFF        // Code Protect (Program memory is not code-protected)

// CONFIG2L
#pragma config OSC = HSPLL      // Oscillator (HS+PLL, USB-HS+PLL)
#pragma config SOSCSEL = HIGH   // T1OSC/SOSC Power Selection Bits (High Power T1OSC/SOSC circuit selected)
#pragma config CLKOEC = ON      // EC Clock Out Enable Bit  (CLKO output enabled on the RA6 pin)
#pragma config FCMEN = ON       // Fail-Safe Clock Monitor (Enabled)
#pragma config IESO = ON        // Internal External Oscillator Switch Over Mode (Enabled)

// CONFIG2H
#pragma config WDTPS = 32768    // Watchdog Postscaler (1:32768)

// CONFIG3L
#pragma config DSWDTOSC = INTOSCREF// DSWDT Clock Select (DSWDT uses INTRC)
#pragma config RTCOSC = T1OSCREF// RTCC Clock Select (RTCC uses T1OSC/T1CKI)
#pragma config DSBOREN = OFF    // Deep Sleep BOR (Disabled)
#pragma config DSWDTEN = OFF    // Deep Sleep Watchdog Timer (Disabled)
#pragma config DSWDTPS = G2     // Deep Sleep Watchdog Postscaler (1:2,147,483,648 (25.7 days))

// CONFIG3H
#pragma config IOL1WAY = ON     // IOLOCK One-Way Set Enable bit (The IOLOCK bit (PPSCON<0>) can be set once)
#pragma config ADCSEL = BIT12   // ADC 10 or 12 Bit Select (12 - Bit ADC Enabled)
#pragma config MSSP7B_EN = MSK7 // MSSP address masking (7 Bit address masking mode)

// CONFIG4L
#pragma config WPFP = PAGE_127  // Write/Erase Protect Page Start/End Location (Write Protect Program Flash Page 127)
#pragma config WPCFG = OFF      // Write/Erase Protect Configuration Region  (Configuration Words page not erase/write-protected)

// CONFIG4H
#pragma config WPDIS = OFF      // Write Protect Disable bit (WPFP<6:0>/WPEND region ignored)
#pragma config WPEND = PAGE_WPFP// Write/Erase Protect Region Select bit (valid when WPDIS = 0) (Pages WPFP<6:0> through Configuration Words erase/write protected)
#pragma config LS48MHZ = SYS48X8// Low Speed USB mode with 48 MHz system clock bit (System clock at 48 MHz USB CLKEN divide-by is set to 8)


#define _XTAL_FREQ 48000000
#include <xc.h>
#include <stdio.h>
#include <stdlib.h>
#include <pic18f47j53.h>



// Declaracion de variables globales

 int flag, statusflag, map, map2, map3, posicion, place, i, j, k,t, puntaje, enter_colision, exit_colision, start;
 int puntajeguardado, timeron;
 unsigned int points;
 


// Funcion de interrupciones
void __interrupt () rutinainterrupciones(void)
{
    if(INTCON3bits.INT1IF){
        
        //if(FuncionDelay6(PORTCbits.RC6) == 1){
    
        INTCON3bits.INT1IF = 0;
        place++;
        
        if(enter_colision == 1){
        
            exit_colision = 1;
            
            
            
          
        //}
        
        }
        
    }
    if(INTCON3bits.INT2IF){
        
         //if(FuncionDelay7(PORTCbits.RC7) == 1){
    
        INTCON3bits.INT2IF = 0;
        place--;
        
        if(enter_colision == 1){
        
            exit_colision = 1;
            
           
         
            
        //} 
            
        }
        
    
    }
    
    if(INTCONbits.TMR0IF){
     
        
        INTCONbits.TMR0IF = 0;
        
        if(timeron == 1){
        
        puntaje++;
        }
        
    }
    
}
    
  
//Prototipo de funciones
void mapeo(void);
void InitEntradasSalidas(void);
void configSPI(void);
void pulso(void);
void inicializacion(void);
void direccion1(void);
void direccion2(void);
char Texto(char A[]);
int mapa(void);
char colision(void);
void InitINT(void);
int car_pos(void);
void cleanDisp(void);
void escritura(void);
int FuncionDelay6(char A[]);
int FuncionDelay7(char A[]);
void configi2c(void);
void clean_memory(void);





// Funcion Principal
void main() 
{
    timeron = 0;
    int Humedad, aux, aux1;
    flag = 0;
    place = 3;
    mapeo();
    InitEntradasSalidas();  //configurar los pines de ES
    configSPI();  
    pulso();
    inicializacion();
    direccion1();
    InitINT();
    mapa();
    clean_memory(); //LIMPIA LA MEMORIA
    
    exit_colision = 0;
    
    int Dhumedad, Dtemp, Temp, MSB, LSB, selector, speed;    
    char vector[10], vector2[15];  
      sprintf(vector,"Ready...");
      Texto(vector);
      __delay_ms(500);
      cleanDisp();
     
      sprintf(vector,"Get set...");
      Texto(vector);
      __delay_ms(500);
      cleanDisp();
      
      sprintf(vector,"GO!");
      Texto(vector);
      __delay_ms(500);
      cleanDisp();
      
      
      
      sprintf(vector,"Nivel  1");
      Texto(vector);
      
      timeron = 1;
      TMR0 = 0;
      T0CONbits.TMR0ON = 1;
      
      //sprintf(vector2, " ");
          
      int map [128] =      {0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                             0b10000001,
                              0b10000011,
                              0b11000011,
                              0b11000011,
                              0b10001011,
                              0b10011101,
                              0b10001001,
                              0b10000001,
                             0b11000001,
                              0b11100001,
                              0b11100001,
                              0b11100011,
                              0b10000011,
                              0b10000011,
                              0b10000111,
                              0b10001111,
                             0b10011111,
                              0b10001111,
                              0b10000111,
                              0b10000011,
                              0b11000001,
                              0b11100111,
                              0b11100111,
                              0b11100001,
                             0b11100001,
                              0b11000001,
                              0b10000001,
                              0b10011001,
                              0b10111001,
                              0b11110001,
                              0b11100001,
                              0b10000001,
                             0b10000001,
                              0b10000001,
                              0b10000011,
                              0b10000111,
                              0b10001111,
                              0b10011111,
                              0b10111111,
                              0b10011111,
                             0b10001111,
                              0b10000111,
                              0b10000011,
                              0b10000001,
                              0b11100001,
                              0b11100001,
                              0b11100001,
                              0b10000011,
                             0b10000111,
                              0b11100011,
                              0b11100001,
                              0b10000001,
                              0b10000001,
                              0b10110001,
                              0b10111001,
                              0b10110001,
                             0b10000001,
                              0b10000001,
                              0b10000001,
                              0b11000001,
                              0b11100001,
                              0b11110001,
                              0b11100001,
                              0b11000001,
                             0b10000001,
                              0b10000101,
                              0b10001111,
                              0b10000101,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                             0b10001001,
                              0b10011101,
                              0b10111101,
                              0b10111101,
                              0b10111101,
                              0b10011001,
                              0b10000001,
                              0b10000001,
                             0b11100111,
                              0b11100111,
                              0b11100111,
                              0b11000011,
                              0b10000001,
                              0b10011001,
                              0b10011001,
                              0b10011001,
                             0b10011001,
                              0b10011001,
                              0b10011001,
                              0b10011001,
                              0b10111101,
                              0b10111101,
                              0b10000001,
                              0b10000001,
                             0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b11000011,
                              0b11100111,
                              0b11110111,
                              0b11110111,
                             0b11110111,
                              0b11110111,
                              0b11110111,
                              0b11110111,
                              0b11110111,
                              0b11110111,
                              0b11110111,
                              0b11110111,
                             0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001};
        
      
      
      
    while(1)
    {  
        
        
        for (speed = 0; speed <2; speed++){
        for (i=0; i<120; i++){ //estaba en 128 pero el mapa se apagaba
            for (k = 0 ; k < (25 - speed*10); k++){
            for (j=0; j<8; j++){
            
                car_pos();
                LATC = 0;
                LATD = posicion;
                __delay_ms(1);
                
                
                LATC = j;
                LATD = map [j+i];
                
                __delay_ms(1);
                
                if(j==0){
                    colision();
                    if(exit_colision == 1){
                        return;
                    }
                }
                
               
            }
        
        }
        
        }
        
        cleanDisp();
      
      sprintf(vector,"Nivel 2");
      Texto(vector);
            
        }
        
         cleanDisp();
      
      sprintf(vector,"Nivel 3");
      Texto(vector);
        
      int map3 [128] =      {0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                             0b10000001,
                              0b10000011,
                              0b10000111,
                              0b10001111,
                              0b10011111,
                              0b10111111,
                              0b10111111,
                              0b10011111,
                             0b10001111,
                              0b11000111,
                              0b11100011,
                              0b11110011,
                              0b11110011,
                              0b11100011,
                              0b10000111,
                              0b10001111,
                             0b10011111,
                              0b10011111,
                              0b10011111,
                              0b10001111,
                              0b11001111,
                              0b11001111,
                              0b11001111,
                              0b11001111,
                             0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10011001,
                              0b10011001,
                              0b10011001,
                              0b10011001,
                             0b10111101,
                              0b10111101,
                              0b10111101,
                              0b10111101,
                              0b10111101,
                              0b10111001,
                              0b10110001,
                              0b10110011,
                             0b10100011,
                              0b10100111,
                              0b10100111,
                              0b10100111,
                              0b10100111,
                              0b10100111,
                              0b11100111,
                              0b11000111,
                             0b11000111,
                              0b11100111,
                              0b11100111,
                              0b10000011,
                              0b10000001,
                              0b10110001,
                              0b10111001,
                              0b10110001,
                             0b10000001,
                              0b10000111,
                              0b10000111,
                              0b11000011,
                              0b11100001,
                              0b11110001,
                              0b11100001,
                              0b11000001,
                             0b10000101,
                              0b10000101,
                              0b10000101,
                              0b10000101,
                              0b10000101,
                              0b10000101,
                              0b10000101,
                              0b10000101,
                             0b10001101,
                              0b10011101,
                              0b11111101,
                              0b11111101,
                              0b11111101,
                              0b11111001,
                              0b11100001,
                              0b11100011,
                             0b11100111,
                              0b11100111,
                              0b11100111,
                              0b11000011,
                              0b10000001,
                              0b10011001,
                              0b10011001,
                              0b10011001,
                             0b10011001,
                              0b10011001,
                              0b10011001,
                              0b10011001,
                              0b10111101,
                              0b10111101,
                              0b10000001,
                              0b10000001,
                             0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b11000011,
                              0b11100111,
                              0b11110111,
                              0b11110111,
                             0b11110111,
                              0b11110111,
                              0b11110111,
                              0b11110111,
                              0b11110111,
                              0b11110111,
                              0b11110111,
                              0b11110111,
                             0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001,
                              0b10000001};
      
      for (speed = 0; speed <2; speed++){
        for (i=0; i<128; i++){
            for (k = 0 ; k < (25 - speed*10); k++){
            for (j=0; j<8; j++){
            
                car_pos();
                LATC = 0;
                LATD = posicion;
                __delay_ms(1);
                
                
                LATC = j;
                LATD = map3 [j+i];
                
                __delay_ms(1);
                
                if(j==0){
                    colision();
                    if(exit_colision == 1){
                        return;
                    }
                }
                
               
            }
        
        }
        
        }
        
        sprintf(vector,"Nivel 4");
      Texto(vector);
            
        }
        
        
    }
}

int car_pos(void)
{
    
   int pos [8] = {0b10000000,0b01000000,0b00100000,0b00010000,0b00001000,0b00000100,0b00000010,0b00000001};
   posicion = pos[place];
           
   //return posicion;
    
}

char colision(void)
{
    if((posicion & LATD) != 0){
      
      T0CONbits.TMR0ON = 0;
      enter_colision = 1; 
      
      
      char vector[15], vector2[15];
      
      
      
      
      cleanDisp();
      sprintf(vector,"Game over :( ");
      Texto(vector);
      __delay_ms(500);
      
      escritura();
      
      cleanDisp();
      direccion1();
      sprintf(vector,"Press to cont.");
      Texto(vector);
      
      
      direccion2();
      
      points = (TMR0/1000)*2 + (140*puntaje);
      
      sprintf(vector2,"Your Score:%lu" , points);
      Texto(vector2);
      
      
      
      
        int map2 [8] =       {0b01111100,
                              0b01010100,
                              0b01000110,
                              0b10000011,
                              0b11001101,
                              0b11001101,
                              0b10000001,
                              0b01000010};
                             
      
        
      while(exit_colision == 0){  
        
            
            for (j=0; j<8; j++){
                
                LATC = j;
                LATD = map2 [j];
                __delay_ms(2);
                
            }
            
         
            
        }
    
    }
}

void escritura(void)
{

    char vector[12];
    
    unsigned char alta, baja, msb, lsb, a;
    a = 0;
    
    unsigned int totalguardado;
    
      cleanDisp();
      direccion1();
      sprintf(vector,"Saving...");
      Texto(vector);
      
      points = (TMR0/1000)*2 + (140*puntaje);
      
      //-------------------------------leer---------------------------
        
        SSP1CON2bits.SEN=1;
        
        while(SSP1CON2bits.SEN == 1){ //espero el start
        } 
      
        SSP1BUF = 0b10100000; //1010 + A2A1A0 + 0 escritura 
        
         __delay_ms(1);
      
        while (SSP1STATbits.R_NOT_W == 1){
             
        }
        SSP1BUF = 0b00000000; // Direccion 00
        while (SSP1STATbits.R_NOT_W == 1){
             
        }
        
        SSP1BUF = 0b00000001; // Direccion 01
        while (SSP1STATbits.R_NOT_W == 1){
             
        }
        
        
        SSP1CON2bits.RSEN=1; //R-start condition
        
        while(SSP1CON2bits.RSEN == 1){ //espero el start
        } 
        
        SSP1BUF = 0b10100001; //1010 + A2A1A0 + 1 lectura
        while (SSP1STATbits.R_NOT_W == 1){
             
        }
        
        SSP1CON2bits.RCEN=1; //Modo recepcion
        
        
        while (SSP1CON2bits.RCEN == 1){         
        } //esperamos 
        
        alta = SSP1BUF;
        
        SSP1CON2bits.ACKDT = 0;
        SSP1CON2bits.ACKEN = 1;
        
        while(SSP1CON2bits.ACKEN == 1){
            }
        
        SSP1CON2bits.RCEN=1; //Modo recepcion
        
        
        while (SSP1CON2bits.RCEN == 1){         
        } //esperamos 
        
        baja = SSP1BUF;
        
        SSP1CON2bits.ACKDT = 1;
        SSP1CON2bits.ACKEN = 1;
        
        while(SSP1CON2bits.ACKEN == 1){
            }
        
        SSP1CON2bits.PEN = 1 ; //inicia la condicion stop SDA SCL
        while(SSP1CON2bits.PEN == 1){ //espero el stop
        }
        
        totalguardado = (alta << 8) + baja ;
      
      //------------------------------escribir--------------------------------
            
        
        if(points > totalguardado){
            
           msb = (points>>8);
           lsb = points;
            
      SSP1CON2bits.SEN=1;
      
      __delay_ms(1);
      
        while(SSP1CON2bits.SEN == 1){ //espero el start
        } 
      
        SSP1BUF = 0b10100000; //1010 + A2A1A0 + 0 escritura 
        
         __delay_ms(1);
      
        while (SSP1STATbits.R_NOT_W == 1){
             
        }
        SSP1BUF = 0b00000000; // Direccion 00
        while (SSP1STATbits.R_NOT_W == 1){
             
        }
        
        SSP1BUF = 0b00000001; // Direccion 01
        while (SSP1STATbits.R_NOT_W == 1){
             
        }
        
        SSP1BUF = msb; // escribir el msb en la dir. 1
        while (SSP1STATbits.R_NOT_W == 1){
             
        }
        
        SSP1BUF = lsb; // escribir el msb en la dir. 2
        while (SSP1STATbits.R_NOT_W == 1){
             
        }
        
        SSP1CON2bits.PEN = 1 ; //inicia la condicion stop SDA SCL
        while(SSP1CON2bits.PEN == 1){ //espero el stop
        }
        
        __delay_ms(100);
        
      cleanDisp();
      direccion1();
      sprintf(vector,"New high score!");
      Texto(vector);
      
      direccion2();
      sprintf(vector,"Score: %lu" , points);
      Texto(vector);
      
      __delay_ms(1000);
      
      a = 1;
        
        }
       
      if (a == 1){  
      cleanDisp();
      direccion1();
      sprintf(vector,"Highest score:");
      Texto(vector);
      
      direccion2();
      sprintf(vector,"%lu points", totalguardado);
      Texto(vector);
      
      __delay_ms(1000);
      }


}

int mapa(void)
{
   
          
    
    
    
}

char Texto(char A[]){
        
        char i, aux, MSB, LSB, total1, total2;
        
        for (i = 0; i < 16; i++ ){
            
            //if((A[i] == 0b00100000) & (A[i+1] == 0b00100000)){
            if(A[i] == 0b00000000){
                break;
            }
            
            else{
            
            aux = A[i]; 
        
        MSB = 0b11110000 & aux;
        LSB = 0b00001111 & aux;
        
        MSB = MSB>>4;
        
        total1 = MSB + 0b10000000;
        total2 = LSB + 0b10000000;
        
        PORTB = total1;
        pulso();
        __delay_ms(30);
        PORTB = total2;
        pulso();
      __delay_ms(30);
      
            }
        }
        flag = 1 ;
    
}

void InitEntradasSalidas(void)
{
    ANCON0 = 0xFF;
    ANCON1 = 0x1F;
    
   
    
    TRISA = 0b11011111; //todos los pin del puerto como entradas excepto enable RA5
    TRISB = 0b00100000; //todos los pin del puerto como Salidas
                //RS=7,RW=6,E=5,D4=0,D5=1,D6=2,D7=3
    TRISC = 0b00000000; // C6 Como chip select
    TRISD = 0b00000000; //Todos como salidas
    
    
    LATCbits.LC6 = 1;
    
}

void InitINT(void)
{

    INTCONbits.GIE = 1; //Habiliito interrupcciones globales
    INTCON3bits.INT1IE = 1; // habilito interrupccion externa int0
    INTCON3bits.INT2IE = 1; // habilito interrupccion externa int0
    INTCON2bits.INTEDG1 = 1; // detecto flanco de subida
    INTCON2bits.INTEDG2 = 1; // detecto flanco de subida
    INTCON3bits.INT1IF = 0; //  Borra el flag de INT0IF.
    INTCON3bits.INT2IF = 0; //  Borra el flag de INT0IF.
    INTCONbits.PEIE = 1; //  Habilita interrupciones PERIFERICAS.
    RCONbits.IPEN = 0; //  deshabilita las Interrupciones de Prioridad.
    
    
    INTCONbits.TMR0IE = 1; // habilito interrupccion externa TMR0
    //INTCON2bits.TMR0IP = 0; // detecto Cambio en bit baja prioridad
    INTCONbits.TMR0IF = 0;
    //RCONbits.IPEN = 0; //  deshabilita las Interrupciones de Prioridad.
    
    T0CONbits.T0CS = 0;
    T0CONbits.T08BIT = 0; //16 bits
    T0CONbits.PSA = 0;
    T0CONbits.T0PS = 0b111; // 1:2
}

void cleanDisp(void)
{
 __delay_ms(10);
    PORTB = 0b00000000;
    pulso();
    PORTB = 0b00000001;
    pulso();
}

void inicializacion(void)
{
    //rutina inicializacion LCD
        __delay_ms(30);
        PORTB= 0b00000011;
        pulso();
        __delay_ms(30);
        PORTB= 0b00000011;
        pulso();
        __delay_ms(30);
        PORTB= 0b00000011;
        pulso();
        //chequear por BF=0
        __delay_ms(30);
        
        PORTB= 0b00000010; //4bits
        pulso();
        //chequear por BF=0
        __delay_ms(30);
        
        PORTB= 0b00000010; 
        pulso();
        PORTB= 0b00001001; //N numero de lineas,F tamaño,x,x ,, lo cambie video
        pulso();
        
        //chequear por BF=0
        __delay_ms(30);
        
        PORTB= 0b00000000; 
        pulso();
        PORTB= 0b00001111; //display off, lo cambie video
        pulso();
        
        //chequear por BF=0
        __delay_ms(30);
        
        PORTB= 0b00000000; 
        pulso();
        PORTB= 0b00000001; //limpia display y cursor al origen
        pulso();
        
        //chequear por BF=0
        __delay_ms(30);
        
        PORTB= 0b00000000; 
        pulso();
        PORTB= 0b00000110; //fija el modo entrada; 0,1,I/D incremento/decremento luego escritura,S corre cursor luego del ingreso
        pulso();
        
        //fin inicializacion

}

void pulso(void)
{
     PORTAbits.RA5 = 1; //E
     __delay_ms(10);
     PORTAbits.RA5 = 0; //E
    
}
void mapeo(void)
{
     INTCONbits.GIE=0; //deshabilito interrupciones
     EECON2=0x55;
     EECON2=0xAA;
     PPSCONbits.IOLOCK=0; //puedo cambiar configuracion de los bits
        
     RPINR1=0; //Asigno INT1
     RPINR2=1; //Asigno INT2
     //RPOR23=10; //Asigno Data Output 2 a RP23 en el pin RD6
     
     //RPINR22= 24; //SPI2 clock input RP24 
     INTCONbits.GIE=0; //deshabilito interrupiones
     EECON2 = 0x55;
     EECON2 = 0xAA;
     PPSCONbits.IOLOCK=1;//habilito protección contra escritura
    
}

void direccion1(void)
{
    //fijo primera linea
        PORTB= 0b00001000;
        pulso();
        PORTB= 0b00000000;
        pulso();
}

void direccion2(void)
{
     //fijo segunda linea
        PORTB= 0b00001100;
        pulso();
        PORTB= 0b00000000;
        pulso();
}


void configSPI(void)
{
     
     SSP1CON1bits.SSPM=0b0001; //modo master, clock= fosc/64
     SSP1CON1bits.CKP = 0; //estado idle clock nivel alto
     SSP1STATbits.CKE = 0;
     SSP1STATbits.SMP = 0;
     SSP1CON1bits.SSPEN=1; //habilita puertos seriales
     
}

int FuncionDelay6 (char A[]){    
    char flagg;
    
		if(A == 1) //pregunto por el primer 1
		{
			__delay_ms(1);
			
            if (A == 1) //confirmo el 1 
            {
                flagg = 0;
                
                while(flagg == 0)
                {
                     if (PORTCbits.RC6 == 0)
                     {
                         __delay_ms(1);
                         
                         if (PORTCbits.RC6 == 0)
                         {
                          flagg = 1;
                          return 1;
                         }                         
                     }                                       
                }                              
            }                                
        }                                 
}

int FuncionDelay7 (char A[]){    
    char flagg;
    
		if(A == 1) //pregunto por el primer 1
		{
			__delay_ms(1);
			
            if (A == 1) //confirmo el 1 
            {
                flagg = 0;
                
                while(flagg == 0)
                {
                     if (PORTCbits.RC7 == 0)
                     {
                         __delay_ms(1);
                         
                         if (PORTCbits.RC7 == 0)
                         {
                          flagg = 1;
                          return 1;
                         }                         
                     }                                       
                }                              
            }                                
        }                                 
}

void clean_memory(void){

      char vector[16],a, dato1, dato2;  


      sprintf(vector,"borrando memoria");
      Texto(vector);
     
      LATCbits.LC6 = 0;
        
        SSP1BUF = 0b00000110; //WREN
        
        while(PIR1bits.SSP1IF == 0){}
        PIR1bits.SSP1IF = 0;
        
        
        
        LATCbits.LC6 = 1;
        
        __delay_ms(1000);
        
        
        
        
        
        ////////////////////////ESCRITURA///////////////////////////////
        
       
        
        
        
        LATCbits.LC6 = 0;             
                        
        
        SSP1BUF = 0b00000010; 
        
        while(PIR1bits.SSP1IF == 0){}
        PIR1bits.SSP1IF = 0;
        
        
        SSP1BUF = 0b00000000; // 00
        
        while(PIR1bits.SSP1IF == 0){}
        PIR1bits.SSP1IF = 0;
        
        SSP1BUF = 0b00000001; // 01
        
        while(PIR1bits.SSP1IF == 0){}
        PIR1bits.SSP1IF = 0;
        
        SSP1BUF = 0b11111010; // FF
        
        while(PIR1bits.SSP1IF == 0){}
        PIR1bits.SSP1IF = 0;
        
        SSP1BUF = 0b10101010; // AA
        
        while(PIR1bits.SSP1IF == 0){}
        PIR1bits.SSP1IF = 0;
        
        LATCbits.LC6 = 1; 
        
        
        
        __delay_ms(1000);
        
        
        /////////////////////////status///////////////////////////////
        
        a = 1;
        
        while( a == 0 ){
        
        LATCbits.LC6 = 0; 
        
        SSP1BUF = 0b00000101; // Read status
                
        
        while(PIR1bits.SSP1IF == 0){}
        PIR1bits.SSP1IF = 0;
        
        while(SSP1STATbits.BF == 0){}
        
        
        if ((SSP1BUF & 0b00000001) == 0b00000001){
            
            a = 0;
        
        }
        
        else {
        
            a = 1;
            
        }
        
        }
        
        ////////////////////////////Lectura///////////////////////////////////////////////
        
        LATCbits.LC6 = 0; 
        
        SSP1BUF = 0b00000011; 
        
        while(PIR1bits.SSP1IF == 0){}
        PIR1bits.SSP1IF = 0;
        
        SSP1BUF = 0b00000000; // 00
        
        while(PIR1bits.SSP1IF == 0){}
        PIR1bits.SSP1IF = 0;
        
        SSP1BUF = 0b00000001; // 01
        
        while(PIR1bits.SSP1IF == 0){}
        PIR1bits.SSP1IF = 0;
                              
        while(PIR1bits.SSP1IF == 0){}
        PIR1bits.SSP1IF = 0;
        
        dato1 = SSP1BUF;
        
        while(PIR1bits.SSP1IF == 0){}
        PIR1bits.SSP1IF = 0;
        
        dato2 = SSP1BUF;
                    
        LATCbits.LC6 = 1; 
        
        
        
        
      cleanDisp();
      direccion1();
      sprintf(vector,"%x", dato1);
      Texto(vector);
      
      direccion2();
      sprintf(vector,"%x", dato2);
      Texto(vector);
        
      while(1){}

}