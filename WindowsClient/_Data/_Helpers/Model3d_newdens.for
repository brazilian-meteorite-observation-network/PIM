

!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
!
!   Adaptation - 2002
!       Daniela Mourao - UNESP/FEG
!       daniela.mourao@unesp.br
!
!
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
C
C	ADAPTATION - 2018
C	ORIOL CAYÓN
C	oriol.cayon@gmail.com
C
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
                                                                                        

CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
C       October 29 2019
C       Improve density and layers
C       Claudia Goepel claudia.goepel@gmx.de
C
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCc
   
   
      
      
      IMPLICIT none 
      

      logical fixed       
      CHARACTER FName1*30,FName2*30
     
 
	INTEGER NV,NCLASS,NOR,LL

        REAL*8 X(3),V(3),X1(3),X2(3)
	REAL*8 RT,R,R1,R2,T,MT,XL,PI,VMT,M
	REAL*8 TFINAL,PASSO,OUTPUT_STEP

	
	REAL*8 H1,LON1, LAT1
	REAL*8 H2,LON2, LAT2
	REAL*8 A0,A1,A2,A3,A4,A5,A6,A7,RHO,VE,POLY,CD,A

	
	REAL*8 densiMeteor,volMeteor,radioMeteor
	
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
C	MT: EARTH MASS
C	RT: EARTH RADIUS (m)
C	A: EFFECTIVE AREA OF THE METEOR (m²)
C	CD: DRAG COEFICIENT
C	L1,L2,L3,L4,L5: LIMITS OF HEIGHT FOR THE DIFFERENTDENSITY MODELS (m)
C	R: RADIUS OF THE METEOR POSITION (m)
C	VM: VELOCITY MODULUS (m/s)
C	H1,H2: HEIGHT OF THE INITIAL COORDINATES (km)
C	LON1,LON2: LONGITUDE OF THE COORDINATES (º)
C	LAT1,LAT2: LATITUDE OF THE COORDINATES (º)
C	V: METEOR VELOCITY (m/s)
C	X: METEOR GEOCENTRIC POSITION (m)
C	A0,A1,A2,A3,A4,A5,A6,A7,POLY,F10,AP,T,MU,HT: DENSITY FUNCTION COEFICIENTS
C	RHO: AIR DENSITY (kg/m³)
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC

                                             
C	NV: NUMBER OF SIMULTANEOUS EQUATIONS INTEGRATING 

     
      NV=3
      
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
! NCLASS      TYPE OF INTEGRATION SYSTEM 
!               y'=F(y,t)   NCLASS=1
!              y"=F(y,t)   NCLASS= -2

!               y"=F(y',y,t)  NCLASS=2
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
      
      NCLASS=2

!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
! NOR  INTEGRATION ORDER
!       NOR= 15, 19, 23, 27
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

      NOR=15                                                            
      
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
! LL  CONTROLS THE PRECISION OF THE INTEGRATION 
!       SS=10**(-LL) .                                                   
!
!      A GOOD VALUE OF LL IS HALF THE NOR VALUE
!      BIG LL -> HIGH PRECISION
!      LL CAN BE RECALCULATED IN THE PROG. 
C      FOR FIXED STEP, TAKE LL  <0, THEN XL IS CONSTANT 
!      
!      
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
      
      LL=12


CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
C
C XL  if LL<=0 then XL creates a sequence of constant lenght
C     The minimum XL : XL = 0.01
C
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC

      XL=0.01

CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
      
            PI=3.1415926535897932384626433832795D0
      
            densiMeteor=3.25d-3
 	    M = 1.d-3
	    volMeteor=M/densiMeteor
	    radioMeteor=(volMeteor*3.d0/(4.d0*PI))**(1.d0/3.d0)/100.d0
	    A=PI*radioMeteor*radioMeteor
       
      
	    RT = 6371000.d0
	    CD = 2.2D0
           

      
      
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
C
C		INITIAL CONDITIONS
C
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC

C	TIME BETWEEN THE TWO COORDINATES

	T = 0.56d0


		
        H1=42.0390d0
        LON1= -84.38637d0
        LAT1=10.41037d0
        
 	H2=35.546d0
        LON2=-84.37854d0
        LAT2=10.40603d0


	
	
C	HEIGHT, LONGITUDE, LATITUDE OF THE FIRST POINT
C	H1 = 114.486748D0
C	LON1 = -44.994061D0
C	LAT1 = -23.186392D0
C	HEIGHT, LONGITUDE, LATITUDE OF THE SECOND POINT
C	H2 = 101.001053D0	
C	LON2 = -45.136848D0
C	LAT2 = -23.23255D0

CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
	

C	CONVERSION TO CARTESIAN
	H1 = H1*1000.D0
	R1 = H1 + RT
	LON1 = LON1*PI/180.d0
        LAT1 = (LAT1*PI/180.d0)

	X1(1)=R1*dcos(LON1)*dcos(LAT1)
	X1(2)=R1*dsin(LON1)*dcos(LAT1)
	X1(3)=R1*dsin(LAT1)

	H2 = H2*1000.D0
	R2 = H2 + RT
	LON2 = LON2*PI/180.d0
        LAT2 = (LAT2*PI/180.d0)
	
	X2(1)=R2*dcos(LON2)*dcos(LAT2)
	X2(2)=R2*dsin(LON2)*dcos(LAT2)
	X2(3)=R2*dsin(LAT2)


C	INITIAL POSITION ( FIRST COORDINATE )

	X(1)=X1(1)
	X(2)=X1(2)
	X(3)=X1(3)

C	INITIAL VELOCITY USING THE TWO POSITIONS AND TIME BETWEEN THEM
	
	V(1)= (X2(1)-X1(1))/T
	V(2)= (X2(2)-X1(2))/T
	V(3)= (X2(3)-X1(3))/T

	VMT = sqrt(V(1)**2.d0+V(2)**2.d0+V(3)**2.d0)

	write(*,*) VMT


CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
C	CORRECTIONS OF VELOCITY



C	CORRECTION OF GRAVITY AND ATMOSPHERE DRAG DESPICABLE (2M/S)




C Tfinal - Integration time
C passo - Integration step
C out_step - Output step
    	TFINAL= 3600.d0
    	PASSO=  0.00001d0
    	OUTPUT_STEP= 0.1d0


CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
C
C OUTPUT_STEP: output result every (APROX) OUTPUT_step 
C             (time t)
C             OUTPUT IS CALLED EVERY OUTPUT_STEP
C
C fixed		  :true if you want the output to be every OUTPUT_STEP
C	
C		  :  false if the program can change the OUTPUT_STEP
C	 	 : if possible use fixed=.false. (a lot faster) 
C		  
C
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
                                                         
      
      fixed=.true.         

CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC      
C
C  FILE NAMES FOR THE OUTPUT FILES
C
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC         
        FName1='Cartesian.dat'   
	FName2='Coordinates.dat'                                      
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
C                     
C     
C
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC


CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
C     
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC

      open (42,file=FName1, status='unknown') 
      open (44,file=FName2, status='unknown') 

      
       
      
      
      
     
      
 123  FORMAT(7F20.10)
   5  FORMAT (A)
   
 

      IF (NOR.eq.15)
     + CALL RA27 (X,V,TFINAL,PASSO,LL,NV,NCLASS,NOR,OUTPUT_STEP,fixed)
      
      
    
      Close(42)
      Close(44)


      STOP
      END
    
 
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
C	SUBROUTINE TO WRITE VELOCITIES AND POSITIONS           
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC

      SUBROUTINE OUTPUT(X,V,TM)

CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
C	TM: ACTUAL TIME
C	R: RADIUS OF THE METEOR POSITION (m)
C	VM: VELOCITY MODULUS (m/s)
C	H: HEIGHT (km)
C	LAT: LATITUDE OF THE METEOR (º)
C	LON: LONGITUDE OF THE METEOR (º)
C	V: METEOR VELOCITY (m/s)
C	X: METEOR GEOCENTRIC POSITION (m)
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
	                                                     
      IMPLICIT NONE
	REAL*8 TM,PI,R,VM,RT,H,LAT,LON
      REAL*8 X(3),V(3)
      



   5  FORMAT (A)
 123  FORMAT(7G25.18)
 125  FORMAT(5G25.18)
      

      PI = 3.1415926535897932384626433832795D0
      RT = 6371000.d0

C	CONVERSION OF CARTESIAN POSITIONS TO COORDINATES
	
      R = dsqrt((X(1))**2 + (X(2))**2 + (X(3))**2)
      VM = dsqrt((V(1))**2 + (V(2))**2 +(V(3))**2)
      H = (R-RT)/1000.d0
      LON = datan2(X(2),X(1))*180.d0/PI
      
      LAT = dasin(X(3)/R)*180.d0/PI

C	CARTESIAN POSITIONS AND VELOCITIES	->	cartesian.dat
      WRITE(42,123) tm,X(1),X(2),X(3),V(1),V(2),V(3)
C	TOTAL VELOCITY, HEIGHT, LONGITUDE, LATITUDE	->	coordinates.dat
      WRITE(44,125) tm,VM,H,LON,LAT
C	TOTAL VELOCITY, HEIGHT	->	screen
      WRITE(*,*) tm,LON,",",LAT,",",H

      RETURN
  
      END        
      
 
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
C
C     SUBROUTINE   FORCE.FOR
C
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC

      SUBROUTINE FORCE(X,V,TM,F)

C:CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
C	G: GRAVITATIONAL CONSTANT
C	MT: EARTH MASS
C	M: METEOR MASS
C	RT: EARTH RADIUS (m)
C	A: EFFECTIVE AREA OF THE METEOR (m²)
C	CD: DRAG COEFICIENT
C	L1,L2,L3,L4,L5: LIMITS OF HEIGHT FOR THE DIFFERENTDENSITY MODELS (m)
C	R: RADIUS OF THE METEOR POSITION (m)
C	VM: VELOCITY MODULUS (m/s)
C	H: HEIGHT (km)
C	V: METEOR VELOCITY (m/s)
C	X: METEOR GEOCENTRIC POSITION (m)
C	F: ACCELERATION (m/s²)
C	A0,A1,A2,A3,A4,A5,A6,A7,POLY,F10,AP,T,MU,HT: DENSITY FUNCTION COEFICIENTS
C	RHO: AIR DENSITY (kg/m³)
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
      
          IMPLICIT NONE
          REAL*8 X(3),V(3),F(3),TM
	  REAL*8 M,G,MT,R,RHO,A,CD,RT,VM
	  REAL*8 A0,A1,A2,A3,A4,A5,A6,A7,POLY
	  REAL*8 T,AP,F10,MU,HT,H
	  REAL*8 L1,L2,L3,L4,L5,L6,L7,L8,L9,L10,L11,L12,L13,L14,L15
          REAL*8 L16,L17,L18,L19,L20,L21,L22,L23,L24,L25,L26,L27,L28,L29
          REAL*8 L30,L31,L32,L33,L34,L35,L36,L37

	  REAL*8 PI

	  REAL*8 densiMeteor,radioMeteor,volMeteor
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
C
C	HERE, THE ACCELERATION EQUATIONS ARE DECLARED AND CALLED AT EVERY
C	INTEGRATION STEP
C
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                   
	
	
            PI=3.1415926535897932384626433832795D0

            densiMeteor=3.25d-3
	    M = 1.d-3
	    volMeteor=M/densiMeteor
	    radioMeteor=(volMeteor*3.d0/(4.d0*PI))**(1.d0/3.d0)/100.d0
	    A=PI*radioMeteor*radioMeteor
	    
	G = 6.67408E-11
	MT = 5.972E24
	RT = 6371000.d0
	CD = 2.2d0
	
		

C		DENSITY LIMITS
C        10 km steps

	L1 = RT
	L2 = RT+10000.d0
	L3 = RT+20000.d0
	L4 = RT+30000.d0
	L5 = RT+40000.d0
	L6 = RT+50000.d0
	L7 = RT+60000.d0
        L8 = RT+70000.d0
        L9 = RT+80000.d0
        L10 = RT+90000.d0
        L11 = RT+100000.d0
        L12 = RT+110000.d0
        L13 = RT+120000.d0
        L14 = RT+130000.d0
        L15 = RT+140000.d0
        L16 = RT+150000.d0
        L17 = RT+160000.d0
        L18 = RT+170000.d0
        L19 = RT+180000.d0
        L20 = RT+190000.d0
        L21 = RT+200000.d0
        
C       50 km step s
        L22 = RT+250000.d0
        L23 = RT+300000.d0
        L24 = RT+350000.d0
        L25 = RT+400000.d0
        L26 = RT+450000.d0
        L27 = RT+500000.d0
        L28 = RT+550000.d0
        L29 = RT+600000.d0
        L30 = RT+650000.d0
        L31 = RT+700000.d0
        L32 = RT+750000.d0
        L33 = RT+800000.d0
        L34 = RT+850000.d0
        L35 = RT+900000.d0
        L36 = RT+950000.d0
        L37 = RT+1000000.d0


C	RADIUS AND VELOCITY MODULUS

	R = dsqrt((X(1))**2 + (X(2))**2 +(X(3))**2)
	VM = dsqrt((V(1))**2 + (V(2))**2 +(V(3))**2)
	

C	HEIGHT IN KM FOR DENSITY CALCULATIONS
	H = (R-RT)/1000.d0
	

C     WHEN HITS THE GROUND
      IF (R<L1)  THEN
	V(1) = 0.d0
	V(2) = 0.d0
	V(3) = 0.d0
	F(1) = 0.d0
	F(2) = 0.d0
	F(3) = 0.d0
	WRITE(*,*) 'The meteor hit the ground!!!!!!!!!'
	STOP
	
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC

C     Density values from:
C     https://ccmc.gsfc.nasa.gov/modelweb/models/nrlmsise00.php

C     Input parameters for 0-200 km
C     year= 2019, month= 3, day= 17, hour= 3.00,
C     Time_type = Universal
C     Coordinate_type = Geographic
C     latitude= -23.55, longitude= 46.63, height= 0.00
C     Prof. parameters: start= 0.00 stop= 200.00 step= 5.00

C     Input parameters for 200-1000 km
C     year= 2019, month= 3, day= 17, hour= 3.00,
C     Time_type = Universal
C     Coordinate_type = Geographic
C     latitude= -23.55, longitude= 46.63, height= 0.00
C     Prof. parameters: start= 200.00 stop= 1000.00 step= 25.00

CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC

C     0-10 km
      ELSE IF ((R .LT. L2) .AND. (R .GT. L1))   THEN
      RHO = 7.081E-01

C     10-20 km
      ELSE IF ((R .LT. L3) .AND. (R .GT. L2))   THEN
      RHO =  2.212E-01

C     20-30 km
      ELSE IF ((R .GT. L3) .AND. (R .LT. L4))   THEN 
      RHO = 4.049E-02

C     30-40 km
      ELSE IF ((R .GT. L4) .AND. (R .LT. L5)) THEN 
      RHO = 8.359E-03

C     40-50 km
      ELSE IF ((R .GT. L5) .AND. (R .LT. L6))   THEN
      RHO = 2.045E-03

C     50-60 km
      ELSE IF ((R .GT. L6) .AND. (R .LT. L7))   THEN
      RHO = 6.119E-04
      
C     60-70 km
      ELSE IF ((R .GT. L7) .AND. (R .LT. L8))   THEN
      RHO = 1.718E-04

C     70-80 km
      ELSE IF ((R .GT. L8) .AND. (R .LT. L9)) THEN
      RHO = 4.147E-05

C     80-90 km
      ELSE IF ((R .GT. L9) .AND. (R .LT. L10)) THEN
      RHO = 8.617E-06

C     90-100 km
      ELSE IF ((R .GT. L10) .AND. (R .LT. L11))   THEN
      RHO = 1.387E-06

C     100-110 km
      ELSE IF ((R .GT. L11) .AND. (R .LT. L12))   THEN
      RHO = 2.156E-07

C     110-120 km
      ELSE IF ((R .GT. L12) .AND. (R .LT. L13))   THEN
      RHO = 4.034E-08
      

C     120-130 km
      ELSE IF ((R .GT. L13) .AND. (R .LT. L14)) THEN
      RHO = 1.170E-08

C     130-140 km
      ELSE IF ((R .GT. L14) .AND. (R .LT. L15)) THEN
      RHO = 5.193E-09

C     140-150 km
      ELSE IF ((R .GT. L15) .AND. (R .LT. L16))   THEN
      RHO = 2.689E-09

C     150-160 km
      ELSE IF ((R .GT. L16) .AND. (R .LT. L17))   THEN
      RHO = 1.528E-09

C     160-170 km
      ELSE IF ((R .GT. L17) .AND. (R .LT. L18))   THEN
      RHO = 9.229E-10

C     170-180 km
      ELSE IF ((R .GT. L18) .AND. (R .LT. L19)) THEN
      RHO = 5.820E-10

C     180-190 km
      ELSE IF ((R .GT. L19) .AND. (R .LT. L20)) THEN
      RHO = 3.791E-10

C     190-200 km
      ELSE IF ((R .GT. L20) .AND. (R .LT. L21))   THEN
      RHO = 2.533E-10

C     200-250 km
      ELSE IF ((R .GT. L21) .AND. (R .LT. L22))   THEN
      RHO = 8.462E-11

C     250-300 km
      ELSE IF ((R .GT. L22) .AND. (R .LT. L23))   THEN
      RHO = 1.761E-11

C     300-350 km
      ELSE IF ((R .GT. L23) .AND. (R .LT. L24)) THEN
      RHO = 4.449E-12

C     350-400 km
      ELSE IF ((R .GT. L24) .AND. (R .LT. L25))   THEN
      RHO = 1.252E-12

C     400-450 km
      ELSE IF ((R .GT. L25) .AND. (R .LT. L26)) THEN
      RHO = 3.794E-13

C     450-500 km
      ELSE IF ((R .GT. L26) .AND. (R .LT. L27))   THEN
      RHO = 1.247E-13

C     500-550 km
      ELSE IF ((R .GT. L27) .AND. (R .LT. L28))   THEN
      RHO = 4.625E-14

C     550-600 km
      ELSE IF ((R .GT. L28) .AND. (R .LT. L29))   THEN
      RHO = 2.039E-14

C     600-650 km
      ELSE IF ((R .GT. L29) .AND. (R .LT. L30)) THEN
      RHO = 1.094E-14

C     650-700 km
      ELSE IF ((R .GT. L30) .AND. (R .LT. L31)) THEN
      RHO = 6.912E-15

C     700-750 km
      ELSE IF ((R .GT. L31) .AND. (R .LT. L32))   THEN
      RHO = 4.849E-15

C     750-800 km
      ELSE IF ((R .GT. L32) .AND. (R .LT. L33))   THEN
      RHO = 3.602E-15

C     800-850 km
      ELSE IF ((R .GT. L33) .AND. (R .LT. L34))   THEN
      RHO = 2.760E-15

C     850-900 km
      ELSE IF ((R .GT. L34) .AND. (R .LT. L35)) THEN
      RHO = 2.154E-15

C     900-950 km
      ELSE IF ((R .GT. L35) .AND. (R .LT. L36)) THEN
      RHO = 1.703E-15

C     950-1000 km
      ELSE IF ((R .GT. L36) .AND. (R .LT. L37))   THEN
      RHO = 1.360E-15


	
      ELSE
      
	write(*,*) 'You are out of the atmosphere!!'
	STOP

      END IF
      		
      F(1) = -RHO*CD*A*(VM)*V(1)/(2.d0*M)-((G*MT)*X(1))/(R**3)
      F(2) = -RHO*CD*A*(VM)*V(2)/(2.d0*M)-((G*MT)*X(2))/(R**3)
      F(3) = -RHO*CD*A*(VM)*V(3)/(2.d0*M)-((G*MT)*X(3))/(R**3)
      

	
	
      RETURN

	
      END        
      
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC      
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
C
C			INTEGRATOR (BLACK BOX)
C
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
                                                    
C
C  $$$$  RA27T.FOR
C
      SUBROUTINE RA27(X,V,TF,XL,LL,NV,NCLASS,NOR,OS,FIXED)
C  Integrator RADAU by E. Everhart, Physics Department, University of Denver
C  Order of integration NOR can be 15, 19, 23, or 27.
C  y'=F(y,t) is  NCLASS=1,  y"=F(y,t) is NCLASS= -2,  y"=F(y',y,t) is NCLASS=2
C  TF is t(final) - t(initial). It may be negative for backward integration.
C  NV = the number of simultaneous differential equations.
C  The dimensioning below assumes NV will not be larger than 18.
C  LL controls sequence size. Thus SS=10**(-LL) controls the size of a term.
C  A typical LL-value is about half NOR. Higher LL leads to more accuracy.
C  However, if LL.LT.0 then XL is the constant sequence size used.
C  X and V enter as the starting position-velocity vector, and are output as
C  the final position-velocity vector.
C  Integration is in double precision, if a 120- to 128-bit double word
C  is available. Some VAX machines have a 128-bit quadruple precision
C  Statement next should by IMPLICIT REAL*16 etc.
      IMPLICIT DOUBLE PRECISION (A-H,O-Z)
      REAL  PW, TVAL
      REAL*8 NEXTOUTPUT
      DIMENSION X(1),V(1),F1(18),FJ(18),C(78),D(78),R(78),
     A XI(78), Y(18), Z(18), B(13,18), G(13,18), H(14), W(13), U(13),
     B E(13,18), BD(13,18), H15(8), H19(10), H23(12), H27(14)
      DIMENSION MC(12), NW(14), NXI(78)
      LOGICAL J2,NPQ,NSF,NPER,NCL,NES,fixed
      DATA NW/0,0,1,3,6,10,15,21,28,36,45,55,66,78/
      DATA MC/1,13,24,34,43,51,58,64,69,73,76,78/
      DATA ZERO, HALF, ONE,SR/0.0D0, 0.5D0, 1.0D0,1.4D0/
      DATA NXI/2,3,4,5,6,7,8,9,10,11,12,13,3,6,10,15,21,28,36,45,55,66,
     A 78,4,10,20,35,56,84,120,165,220,286,5,15,35,70,126,210,330,495,
     B 715, 6,21,56,126,252,462,792,1287, 7,28,84,210,462,924,1716,
     C  8,36,120,330,792,1716, 9,45,165,495,1287, 10,55,220,715,11,66,
     D  286, 12,78,13/
C  These next values are the Gauss-Radau spacings, scaled to the range
C  -1 to +1 from Stroud and Secrest. Orders are 15, 19, 23, and 27.
      DATA H15/                  -1.D0,-.8874748789261557070686956179D0,
     A-.6395186165262152700248401143D0,-.2947505657736607252521844596D0,
     B .0943072526611107660028971153D0, .4684203544308210630464212166D0,
     C .7706418936781915361807195258D0, .9550412271225750037823490008D0/
      DATA H19/                  -1.D0,-.9274843742335810781176713984D0,
     D-.7638420424200025996154297760D0,-.5256460303700792293653866142D0,
     E-.2362344693905880492784595032D0, .0760591978379781302337137826D0,
     F .3806648401447243658807590655D0, .6477666876740094362736485078D0,
     G .8512252205816079107281636280D0, .9711751807022469027343465183D0/
      DATA H23/                  -1.D0,-.9494527592049593004933376270D0,
     H-.8339167731051897065862692540D0,-.6616497992456371480611330878D0,
     I-.4444065697819358511266426156D0,-.1969945595342783664554414273D0,
     J .0637247738208319158337792384D0, .3199836841706696235327895322D0,
     K .5543187859123242889843370930D0, .7507615497111138525294008254D0,
     L .8959290977456388948329146084D0, .9799634390766391883139505402D0/
      DATA H27/                  -1.D0,-.9627792699780242971205612443D0,
     M-.8770489182014620247952667735D0,-.7473896426133788387354291342D0,
     N-.5803140565468749711057266649D0,-.3842020034392033137940839033D0,
     O-.1688879280426809110084416956D0, .0548312279917645496498107146D0,
     P .2757372054355223991826374035D0, .4827529185884749668204185343D0,
     Q .6654979772168845370089550424D0, .8148095506019947294342172491D0,
     R .9232037225206432992463349502D0, .9852706979478213566986170031D0/
      IF(NOR.EQ.15.OR.NOR.EQ.19.OR.NOR.EQ.23.OR.NOR.EQ.27) GO TO 2
      WRITE(*,4)
   4  FORMAT(40H Order NOR must be 15, 19, 23, or 27        )
      RETURN
      
   2  Out=OS
      KD=(NOR-3)/2
      KE=KD+1
      KF=KD+2
      LA=KD/2-2
      NI=10
   5  FORMAT(1X,D40.30)
      GO TO (15,19,23,27),LA
  15  DO 115 N=1,8
 115  H(N)=HALF*(H15(N)+ONE)
      GO TO 200
  19  DO 119 N=1,10
 119  H(N)=HALF*(H19(N)+ONE)
      GO TO 200
  23  DO 123 N=1,12
 123  H(N)=HALF*(H23(N)+ONE)
      GO TO 200
  27  DO 127 N=1,14
 127  H(N)=HALF*(H27(N)+ONE)
C  Loop 18 below sums the H-values as HV. If this sum equals TEMP, as
C  calculated independently below, then there are no errors in H-values.
C  From this point forward this very high-order integrator is identical to
C  RA715, the 7th through 15th order version written with loops.
 200  HV=ZERO
      DO 18 N=1,KF
  18  HV=HV+H(N)
      TEMP=KE*KF
      RES=NOR
      TEMP=TEMP/RES
      PW=2./FLOAT(NOR+3)
      NPER=.FALSE.
      NSF=.FALSE.
      NCL=NCLASS.EQ.1
      NPQ=NCLASS.LT.2
C  y'=F(y,t)  NCL=.TRUE.    y"=F(y,t)  NCL=.FALSE.   y"=F(y',y,t) NCL=.FALSE.
C  NCLASS=1   NPQ=.TRUE.    NCLASS= -2 NPQ=.TRUE.    NCLASS= 2    NPQ=.FALSE.
C  NSF is .FALSE. on starting sequence, otherwise .TRUE.
C  NPER is .TRUE. only on last sequence of the integration.
C  NES is .TRUE. only if LL is negative. Then the sequence size is XL.
      DIR=ONE
      IF(TF.LT.ZERO) DIR=-ONE
      NES=LL.LT.0
      XL=DIR*DABS(XL)
C  Evaluate the constants in the W-, U-. C-, D-, R-, and XI- vectors.
      DO 14 N=2,KF
      WW=N+N*N
      IF(NCL) WW=N
      W(N-1)=ONE/WW
      WW=N
  14  U(N-1)=ONE/WW
      DO 22 K=1,NV
      IF(NCL) V(K)=ZERO
      DO 22 L=1,KE
  22  B(L,K)=ZERO
      W1=HALF
      IF(NCL) W1=ONE
      DO 939 J=1,KD
      M=MC(J)
      JD=J+1
      DO 939 L=JD,KE
      XI(M)=NXI(M)
 939  M=M+1
      C(1)=-H(2)
      D(1)=H(2)
      R(1)=ONE/(H(3)-H(2))
      LA=1
      LC=1
      DO 73 K=3,KE
      LB=LA
      LA=LC+1
      LC=NW(K+1)
      C(LA)=-H(K)*C(LB)
      C(LC)=C(LA-1)-H(K)
      D(LA)=H(2)*D(LB)
      D(LC)=-C(LC)
      R(LA)=ONE/(H(K+1)-H(2))
      R(LC)=ONE/(H(K+1)-H(K))
      IF(K.EQ.3) GO TO 73
      DO 72 L=4,K
      LD=LA+L-3
      LE=LB+L-4
      C(LD)=C(LE)-H(K)*C(LE+1)
      D(LD)=D(LE)+H(L-1)*D(LE+1)
  72  R(LD)=ONE/(H(K+1)-H(L-1))
  73  CONTINUE
      SS=10.**(-LL)
C  The statements above are uaed only once in an integration to set up the
C  constants. They use less than a second of execution time.  Next set in
C  a reasonable estimate to TP based on experience. Same sign as DIR.
C  Note that an initial step size can be set through XL even with LL positive.
      TP=0.1D0*DIR
      IF(XL.NE.ZERO) TP=XL
      IF(NES) TP=XL
      IF(TP/TF.GT.HALF) TP=HALF*TF
      NCOUNT=0

   3  FORMAT(A)
C  Line 4000 is the starting place of first sequence of actual integration.
4000  NS=0
      NF=0
      TM=ZERO
      CALL FORCE (X, V, ZERO, F1)
      NF=NF+1
C  Line 722 is the beginning of every sequence after the first. Loop 58 finds
C  new G-values from the predicted B-values, following Eq. (2.7) of text.
 722  DO 58 K=1,NV
      G(KE,K)=B(KE,K)
      DO 58 J=1,KD
      JD=J+1
      G(J,K)=B(J,K)
      DO 58 L=JD,KE
      N=NW(L)+J
  58  G(J,K)=G(J,K)+D(N)*B(L,K)
      T=TP
      T2=T*T
      IF(NCL) T2=T
      TVAL=DABS(T)
      
      
      IF(fixed.and.DABS(DIR*TM-OUT+OS).le.1.d-8) call  
     +OUTPUT(X,V,TM)
     
      IF (fixed.or.(out-os-dir*tm).gt.1.d-8)
     +go to 246
      call OUTPUT(X,V,TM)
      Out=out+os
  246 continue
  

C  Loop 175 is 6 iterations on first sequence and two iterations therafter.
      DO 175 M=1,NI
      J2=.TRUE.
C  Loop 174 is for each substep within a sequence.
      DO 174 J=2,KF
      JD=J-1
      LA=NW(JD)
      JDM=J-2
      S=H(J)
      Q=S
      IF(NCL) Q=ONE
C  Use Eqs. (2.9) and (2,10) of text to predict positions at each substep.
      DO 130 K=1,NV
      RES=B(KE,K)*W(KE)
      DO 234 L=1,KD
      JR=KE-L
 234  RES=B(JR,K)*W(JR)+S*RES
      Y(K)=X(K)+Q*(T*V(K)+T2*S*(F1(K)*W1+S*RES))
      IF(NPQ) GO TO 130
C  Next are calculated the velocity predictors needed for general class II.
      RES=B(KE,K)*U(KE)
      DO 734 L=1,KD
      JR=KE-L
 734  RES=B(JR,K)*U(JR)+S*RES
      Z(K)=V(K)+S*T*(F1(K)+S*RES)
 130  CONTINUE
      CALL FORCE(Y,Z,TM+S*T,FJ)
      NF=NF+1
C  Find G-values from the force FJ found at the current substep. Eq. (2.4).
      DO 171 K=1,NV
      TEMP=G(JD,K)
      RES=(FJ(K)-F1(K))/S
      IF(J2) GO TO 132
      N=LA
      DO 134 L=1,JDM
      N=N+1
 134  RES=(RES-G(L,K))*R(N)
 132  G(JD,K)=RES
C  Upgrade B-values. This section based on Eq. (2.5).
      TEMP=RES-TEMP
      B(JD,K)=B(JD,K)+TEMP
      IF(J2) GO TO 171
      N=LA
      DO 150 L=1,JDM
      N=N+1
 150  B(L,K)=B(L,K)+C(N)*TEMP
 171  CONTINUE
 174  J2=.FALSE.
      IF(NES.OR.M.LT.NI) GO TO 175
C  Integration of sequence is over. Next is sequence size control.
      HV=ZERO
      DO 635 K=1,NV
 635  HV=DMAX1(HV,DABS(B(KE,K)))
      HV=HV*W(KE)/TVAL**KE
 175  CONTINUE
      IF (NSF) GO TO 180
      IF(.NOT.NES) TP=(SS/HV)**PW*DIR
      IF(NES) TP=XL
      IF(NES) GO TO 170
      IF(TP/T.GT.ONE) GO TO 170
   8  FORMAT (2X,2I2,2D18.10)
      TP=.8D0*TP
      NCOUNT=NCOUNT+1
      IF(NCOUNT.GT.10) RETURN
C  Restart with 0.8x sequence size if new size called for is smaller than
C  originally chosen starting sequence size on first sequence.
      GO TO 4000
 170  NSF=.TRUE.
C Loop 35 finds new X and V values at end of sequence using Eqs.(2.11),(2.12).
 180  DO 35 K=1,NV
      RES=B(KE,K)*W(KE)
      DO 34 L=1,KD
  34  RES=RES+B(L,K)*W(L)
      X(K)=X(K)+V(K)*T+T2*(F1(K)*W1+RES)
      IF(NCL) GO TO 35
      RES=B(KE,K)*U(KE)
      DO 33 L=1,KD
  33  RES=RES+B(L,K)*U(L)
      V(K)=V(K)+T*(F1(K)+RES)
  35  CONTINUE
      TM=TM+T
      NS=NS+1
C  Return if done.
      IF(.NOT.NPER) GO TO 78
      CALL OUTPUT(X,V,TM)
      RETURN
C  Control on size of next sequence and adjust last sequence to exactly
C  cover the integration span. NPER=.TRUE. set on last sequence.
78    CALL FORCE (X,V,TM,F1)
      NF=NF+1
      IF(NES) GO TO 341
      TP=DIR*(SS/HV)**PW
      IF(TP/T.GT.SR) TP=T*SR
 341  IF(NES) TP=XL
      IF(DIR*(TM+TP).LT.DIR*TF-1.D-8) GO TO 66
      TP=TF-TM
      NPER=.TRUE.
      
 66   IF (.not.fixed.or.DIR*(TM+TP).LT.OUT-1.D-8) GO TO 77
      TP=DIR*OUT-TM
      OUT=OUT+OS 
C  Now predict B-values for next step. The predicted values from the preceding
C  sequence were saved in the E-matrix. The correction BD between the actual
C  B-values found amd these predicted values is applied in advance to the
C  next sequence. The gain in accuracy is usually worthwhile. Using Eqs.(2,13)
  77  Q=TP/T
      DO 39 K=1,NV
      RES=ONE
      DO 39 J=1,KE
      IF(NS.GT.1) BD(J,K)=B(J,K)-E(J,K)
      IF(J.EQ.KE) GO TO 740
      M=MC(J)
      JD=J+1
      DO 40 L=JD,KE
      B(J,K)=B(J,K)+XI(M)*B(L,K)
  40  M=M+1
 740  RES=RES*Q
      TEMP=RES*B(J,K)
      B(J,K)=TEMP+BD(J,K)
  39  E(J,K)=TEMP
C  Note that here we iterate 3 times/sequence. RA27.FOR only.
      NI=3
      GO TO 722
      END

C
C  $$$$  RA15T.FOR
C
      SUBROUTINE RA15(X,V,TF,XL,LL,NV,NCLASS,NOR,OS,FIXED)
C  Integrator RADAU by E. Everhart, Physics Department, University of Denver
C  This 15th-order version, called RA15, is written out for faster execution.
C  y'=F(y,t) is  NCLASS=1,  y"=F(y,t) is NCLASS= -2,  y"=F(y',y,t) is NCLASS=2
C  TF is t(final) - t(initial). It may be negative for backward integration.
C  NV = the number of simultaneous differential equations.
C  The dimensioning below assumes NV will not be larger than 18.
C  LL controls sequence size. Thus SS=10**(-LL) controls the size of a term.
C  A typical LL-value is in the range 6 to 12 for this order 11 program.
C  However, if LL.LT.0 then XL is the constant sequence size used.
C  X and V enter as the starting position-velocity vector, and are output as
C  the final position-velocity vector.
C  Integration is in double precision. A 64-bit double-word is assumed.
      IMPLICIT REAL*8 (A-H,O-Z)
      REAL *4 TVAL,PW
      REAL*8 NEXTOUTPUT
      DIMENSION X(1),V(1),F1(18),FJ(18),C(21),D(21),R(21),Y(18),Z(18),
     A     B(7,18),G(7,18),E(7,18),BD(7,18),H(8),W(7),U(7),NW(8)
      LOGICAL NPQ,NSF,NPER,NCL,NES,fixed
      DATA NW/0,0,1,3,6,10,15,21/
      DATA ZERO, HALF, ONE,SR/0.0D0, 0.5D0, 1.0D0,1.4D0/
C  These H values are the Gauss-Radau spacings, scaled to the range 0 to 1,
C  for integrating to order 15.
      DATA H/         0.D0, .05626256053692215D0, .18024069173689236D0,
     A.35262471711316964D0, .54715362633055538D0, .73421017721541053D0,
     B.88532094683909577D0, .97752061356128750D0/
C  The sum of the H-values should be 3.73333333333333333
      NPER=.FALSE.
      NSF=.FALSE.
      NCL=NCLASS.EQ.1
      NPQ=NCLASS.LT.2
      Out=OS
C  y'=F(y,t)  NCL=.TRUE.    y"=F(y,t)  NCL=.FALSE.   y"=F(y',y,t) NCL=.FALSE.
C  NCLASS=1   NPQ=.TRUE.    NCLASS= -2 NPQ=.TRUE.    NCLASS= 2    NPQ=.FALSE.
C  NSF is .FALSE. on starting sequence, otherwise .TRUE.
C  NPER is .TRUE. only on last sequence of the integration.
C  NES is .TRUE. only if LL is negative. Then the sequence size is XL.
      DIR=ONE
      IF(TF.LT.ZERO) DIR=-ONE
      NES=LL.LT.0
      XL=DIR*DABS(XL)
      PW=1./9.
C  Evaluate the constants in the W-, U-, C-, D-, and R-vectors
      DO 14 N=2,8
      WW=N+N*N
      IF(NCL) WW=N
      W(N-1)=ONE/WW
      WW=N
  14  U(N-1)=ONE/WW
      DO 22 K=1,NV
      IF(NCL) V(K)=ZERO
      DO 22 L=1,7
      BD(L,K)=ZERO
  22  B(L,K)=ZERO
      W1=HALF
      IF(NCL) W1=ONE
      C(1)=-H(2)
      D(1)=H(2)
      R(1)=ONE/(H(3)-H(2))
      LA=1
      LC=1
      DO 73 K=3,7
      LB=LA
      LA=LC+1
      LC=NW(K+1)
      C(LA)=-H(K)*C(LB)
      C(LC)=C(LA-1)-H(K)
      D(LA)=H(2)*D(LB)
      D(LC)=-C(LC)
      R(LA)=ONE/(H(K+1)-H(2))
      R(LC)=ONE/(H(K+1)-H(K))
      IF(K.EQ.3) GO TO 73
      DO 72 L=4,K
      LD=LA+L-3
      LE=LB+L-4
      C(LD)=C(LE)-H(K)*C(LE+1)
      D(LD)=D(LE)+H(L-1)*D(LE+1)
  72  R(LD)=ONE/(H(K+1)-H(L-1))
  73  CONTINUE
      SS=10.**(-LL)
C  The statements above are used only once in an integration to set up the
C  constants. They use less than a second of execution time.  Next set in
C  a reasonable estimate to TP based on experience. Same sign as DIR.
C  An initial first sequence size can be set with XL even with LL positive.
      TP=0.1D0*DIR
      IF(XL.NE.ZERO) TP=XL
      IF(NES) TP=XL
      IF(TP/TF.GT.HALF) TP=HALF*TF
      NCOUNT=0

C  An * is the symbol for writing on the monitor. The printer is unit 4.
C  Line 4000 is the starting place of the first sequence.
4000  NS=0
      NF=0
      NI=6
      TM=ZERO
      CALL FORCE (X, V, ZERO, F1)
      NF=NF+1
C Line 722 is begins every sequence after the first. First find new beta-
C  values from the predicted B-values, following Eq. (2.7) in text.
 722  DO 58 K=1,NV
      G(1,K)=B(1,K)+D(1)*B(2,K)+
     X  D(2)*B(3,K)+D(4)*B(4,K)+D( 7)*B(5,K)+D(11)*B(6,K)+D(16)*B(7,K)
      G(2,K)=            B(2,K)+
     X  D(3)*B(3,K)+D(5)*B(4,K)+D( 8)*B(5,K)+D(12)*B(6,K)+D(17)*B(7,K)
      G(3,K)=B(3,K)+D(6)*B(4,K)+D( 9)*B(5,K)+D(13)*B(6,K)+D(18)*B(7,K)
      G(4,K)=            B(4,K)+D(10)*B(5,K)+D(14)*B(6,K)+D(19)*B(7,K)
      G(5,K)=                         B(5,K)+D(15)*B(6,K)+D(20)*B(7,K)
      G(6,K)=                                      B(6,K)+D(21)*B(7,K)
  58  G(7,K)=                                                   B(7,K)
      T=TP
      T2=T*T
      IF(NCL) T2=T
      TVAL=DABS(T)
  
 

      IF(fixed.and.DABS(DIR*TM-OUT+OS).le.1.d-8) call  
     +OUTPUT(X,V,TM)
     
      IF (fixed.or.(out-os-dir*tm).gt.1.d-8)
     +go to 246
      call OUTPUT(X,V,TM)
      Out=out+os
  246 continue
  
      
C  Loop 175 is 6 iterations on first sequence and two iterations therafter.
      DO 175 M=1,NI
C  Loop 174 is for each substep within a sequence.
      DO 174 J=2,8
      JD=J-1
      JDM=J-2
      S=H(J)
      Q=S
      IF(NCL) Q=ONE
C  Use Eqs. (2.9) and (2.10) of text to predict positions at each aubstep.
C  These collapsed series are broken into two parts because an otherwise
C  excellent  compiler could not handle the complicated expression.
      DO 130 K=1,NV
      A=W(3)*B(3,K)+S*(W(4)*B(4,K)+S*(W(5)*B(5,K)+S*(W(6)*B(6,K)+
     V   S*W(7)*B(7,K))))
      Y(K)=X(K)+Q*(T*V(K)+T2*S*(F1(K)*W1+S*(W(1)*B(1,K)+S*(W(2)*B(2,K)
     X  +S*A))))
      IF(NPQ) GO TO 130
C  Next are calculated the velocity predictors need for general class II.
      A=U(3)*B(3,K)+S*(U(4)*B(4,K)+S*(U(5)*B(5,K)+S*(U(6)*B(6,K)+
     T    S*U(7)*B(7,K))))
      Z(K)=V(K)+S*T*(F1(K)+S*(U(1)*B(1,K)+S*(U(2)*B(2,K)+S*A)))
 130  CONTINUE
C  Find forces at each substep.
      CALL FORCE(Y,Z,TM+S*T,FJ)
      NF=NF+1
      DO 171 K=1,NV
C  Find G-value for the force FJ found at the current substep. This
C  section, including the many-branched GOTO, uses Eq. (2.4) of text.
      TEMP=G(JD,K)
      GK=(FJ(K)-F1(K))/S
      GO TO (102,102,103,104,105,106,107,108),J
 102  G(1,K)=GK
      GO TO 160
 103  G(2,K)=(GK-G(1,K))*R(1)
      GO TO 160
 104  G(3,K)=((GK-G(1,K))*R(2)-G(2,K))*R(3)
      GO TO 160
 105  G(4,K)=(((GK-G(1,K))*R(4)-G(2,K))*R(5)-G(3,K))*R(6)
      GO TO 160
 106  G(5,K)=((((GK-G(1,K))*R(7)-G(2,K))*R(8)-G(3,K))*R(9)-
     X     G(4,K))*R(10)
      GO TO 160
 107  G(6,K)=(((((GK-G(1,K))*R(11)-G(2,K))*R(12)-G(3,K))*R(13)-
     X     G(4,K))*R(14)-G(5,K))*R(15)
      GO TO 160
 108  G(7,K)=((((((GK-G(1,K))*R(16)-G(2,K))*R(17)-G(3,K))*R(18)-
     X     G(4,K))*R(19)-G(5,K))*R(20)-G(6,K))*R(21)
C  Upgrade all B-values.
 160  TEMP=G(JD,K)-TEMP
      B(JD,K)=B(JD,K)+TEMP
C  TEMP is now the improvement on G(JD,K) over its former value.
C  Now we upgrade the B-value using this dfference in the one term.
C  This section is based on Eq. (2.5).
      GO TO (171,171,203,204,205,206,207,208),J
 203  B(1,K)=B(1,K)+C(1)*TEMP
      GO TO 171
 204  B(1,K)=B(1,K)+C(2)*TEMP
      B(2,K)=B(2,K)+C(3)*TEMP
      GO TO 171
 205  B(1,K)=B(1,K)+C(4)*TEMP
      B(2,K)=B(2,K)+C(5)*TEMP
      B(3,K)=B(3,K)+C(6)*TEMP
      GO TO 171
 206  B(1,K)=B(1,K)+C(7)*TEMP
      B(2,K)=B(2,K)+C(8)*TEMP
      B(3,K)=B(3,K)+C(9)*TEMP
      B(4,K)=B(4,K)+C(10)*TEMP
      GO TO 171
 207  B(1,K)=B(1,K)+C(11)*TEMP
      B(2,K)=B(2,K)+C(12)*TEMP
      B(3,K)=B(3,K)+C(13)*TEMP
      B(4,K)=B(4,K)+C(14)*TEMP
      B(5,K)=B(5,K)+C(15)*TEMP
      GO TO 171
 208  B(1,K)=B(1,K)+C(16)*TEMP
      B(2,K)=B(2,K)+C(17)*TEMP
      B(3,K)=B(3,K)+C(18)*TEMP
      B(4,K)=B(4,K)+C(19)*TEMP
      B(5,K)=B(5,K)+C(20)*TEMP
      B(6,K)=B(6,K)+C(21)*TEMP
 171  CONTINUE
 174  CONTINUE
      IF(NES.OR.M.LT.NI) GO TO 175
C  Integration of sequence is over. Next is sequence size control.
      HV=ZERO
      DO 635 K=1,NV
 635  HV=DMAX1(HV,DABS(B(7,K)))
      HV=HV*W(7)/TVAL**7
 175  CONTINUE
      IF (NSF) GO TO 180
      IF(.NOT.NES) TP=(SS/HV)**PW*DIR
      IF(NES) TP=XL
      IF(NES) GO TO 170
      IF(TP/T.GT.ONE) GO TO 170
   8  FORMAT (A,2X,2I2,2D18.10)
      TP=.8D0*TP
      NCOUNT=NCOUNT+1
      IF(NCOUNT.GT.10) RETURN
     
      
C  Restart with 0.8x sequence size if new size called for is smaller than
C  originally chosen starting sequence size on first sequence.
      GO TO 4000
 170  NSF=.TRUE.
C Loop 35 finds new X and V values at end of sequence using Eqs. (2.11),(2.12)
 180  DO 35 K=1,NV
      X(K)=X(K)+V(K)*T+T2*(F1(K)*W1+B(1,K)*W(1)+B(2,K)*W(2)+B(3,K)*W(3)
     X    +B(4,K)*W(4)+B(5,K)*W(5)+B(6,K)*W(6)+B(7,K)*W(7))
      IF(NCL) GO TO 35
      V(K)=V(K)+T*(F1(K)+B(1,K)*U(1)+B(2,K)*U(2)+B(3,K)*U(3)
     V    +B(4,K)*U(4)+B(5,K)*U(5)+B(6,K)*U(6)+B(7,K)*U(7))
  35  CONTINUE
      TM=TM+T
      NS=NS+1
C  Return if done.
      IF(.NOT.NPER) GO TO 78
      CALL OUTPUT(X,V,TM)
      RETURN
C  Control on size of next sequence and adjust last sequence to exactly
C  cover the integration span. NPER=.TRUE. set on last sequence.
  78  CALL FORCE (X,V,TM,F1)
      NF=NF+1
      IF(NES) GO TO 341
      TP=DIR*(SS/HV)**PW
      IF(TP/T.GT.SR) TP=T*SR
 341  IF(NES) TP=XL
      IF(DIR*(TM+TP).LT.DIR*TF-1.D-8) GO TO 66
      TP=TF-TM
      NPER=.TRUE.

 66   IF (.not.fixed.or.DIR*(TM+TP).LT.OUT-1.D-8) GO TO 77
      TP=DIR*OUT-TM
      OUT=OUT+OS 
      
C  Now predict B-values for next step. The predicted values from the preceding
C  sequence were saved in the E-matrix. Te correction BD between the actual
C  B-values found and these predicted values is applied in advance to the
C  next sequence. The gain in accuracy is significant. Using Eqs. (2.13):
  77  Q=TP/T
      DO 39 K=1,NV
      IF(NS.EQ.1) GO TO 31
      DO 20 J=1,7
  20  BD(J,K)=B(J,K)-E(J,K)
  31  E(1,K)=      Q*(B(1,K)+ 2.D0*B(2,K)+ 3.D0*B(3,K)+
     X           4.D0*B(4,K)+ 5.D0*B(5,K)+ 6.D0*B(6,K)+ 7.D0*B(7,K))
      E(2,K)=                Q**2*(B(2,K)+ 3.D0*B(3,K)+
     Y           6.D0*B(4,K)+10.D0*B(5,K)+15.D0*B(6,K)+21.D0*B(7,K))
      E(3,K)=                             Q**3*(B(3,K)+
     Z           4.D0*B(4,K)+10.D0*B(5,K)+20.D0*B(6,K)+35.D0*B(7,K))
      E(4,K)=   Q**4*(B(4,K)+ 5.D0*B(5,K)+15.D0*B(6,K)+35.D0*B(7,K))
      E(5,K)=                Q**5*(B(5,K)+ 6.D0*B(6,K)+21.D0*B(7,K))
      E(6,K)=                             Q**6*(B(6,K)+ 7.D0*B(7,K))
      E(7,K)=                                           Q**7*B(7,K)
      DO 39 L=1,7
  39  B(L,K)=E(L,K)+BD(L,K)
C  Two iterations for every sequence after the first.
      NI=2
      GO TO 722
      END
      
     
