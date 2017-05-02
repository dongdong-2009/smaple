<!--




PlTID = 0;PlInt = 40;

PlwI = 3600 / PlInt;

IsStart = 0;

IsTOv = 0;

RLCx = new Array(33);

RLCy = new Array(33);

RLPx = new Array(33);

RLDis = new Array(33);

RLWid = new Array(33);

Dist = 0;

G = 0;

TimeL = 30;

Time = 0;

Speed = 0;

SpMax = 300;

MSPN = 0;

MCarP = new Array(185, 245);

MCRPx = 218;

IsDrift = 0;

DriftD = 0;

IsSpn = 0;

SpnN = 0;

ChkP = new Array(1000, 2000, 3000);

CCol = new Array("#62c400", "#e2b252", "#ffffff");

CNum = 0;

IsGoal = 0;

CGPS = new Array(0, 0);

UpLT = 10;

SkyX = 0;

WhSG = new Array(0, 2, 4, 6, 8);

SGNum = 0;

IsSGNUp = 1;

SGP = new Array(20, 40, 60, 80, 100);

LSGP = 100;

SGSpaP = 20;

SGSPP = 8;

NCSpd = 160;

NCSPN = new Array(9, 9, 9);

NCSPPx = new Array(3);

NCSPX = new Array(3);

NCSPD = new Array(0, 0, 0);

NCSPZ = new Array(3);

NCLDis = 0;

NCSpaD = 20;

ACSpMax = 300;

ACSpMid = 260;

ACSpd = ACSpMid;

ACSPPx = 1;

ACSPX = 0;

ACSPD = 0;

ACSPZ = 0;

IsACar = 1;

ACSDx = 0;

IsAGoal = 0;

MCAData = new Array(10, 11, 12, 13, 14, 15, 16, 0);

mcad_p = 1;

LuWData = new Array(	2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1,	1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,	1, 1, 1, 1, 1, 1, 1, 1, 3, 3, 3, 3, 3, 0);

WhMess = 0;


MessC = 10;

MessOx = 155;

LuP = new Array(233, 240);

LuS = new Array(16, 48);

LStC = 0;

pvL = 0;

MaxC = 2;

G1AData = new Array(0, 17, 18);

HaPx = new Array(205, 205, 205);

HaPy = new Array(245, 245, 245);

HaDx = new Array(0, -1, 1);

HaDy = new Array(-2, -1, -1);

HaPyMax = new Array(125, 130, 130);


HaAppC = new Array(12, 15, 18);

IsHaApp = new Array(0, 0, 0);

G1ACnt = 0;

hst = 0;

IsEndA = 0;



function IntPl(){

	clearTimeout(PlTID);

	if (WhMess == 1){

		if (MessC > 0) MessC--;

		else{	MessSP.style.visibility = "hidden";

			MessSP.style.left = MessOx;

			WhMess = 0;

		}

	}

	if (!IsStart) FAnim(1);

	else if (IsGoal == 1){

		FAnim(2);

		if (IsEndA){

			if (FGOver(1)) return;

		}

	}

	else if (IsGoal == 2){

		FAnim(3);

		if (IsEndA){

			if (FGOver(2)) return;

		}

	}

	else if (IsTOv){

		if (FGOver(0)) return;

	}

	else FPMain();

		PlTID = setTimeout("IntPl()", PlInt);

}

function FGOver(w){

	if (!Cnt && w){

		s1 = (TimeL - Math.floor(Time)) * 100;

		s2 = 0;

		if (w == 1) s2 = 2000;

		GOMessSP[3].innerText = " TIME:" + s1;

		GOMessSP[4].innerText = "BONUS:" + s2;

		GOMessSP[5].innerText = "TOTAL:" + (s1 + s2);

		for (i = 1; i < 7; i++)

			GOMessSP[i].style.visibility = "visible";

				Cnt++;	}

		if (ON_KEY[5]){

		retTW();

		return 1;

	}

	return 0;

}


function retTW(){

	SkySP.visibility = "hidden";

	for (i = 0; i < 66; i++)

 RLSP[i].visibility = "hidden";

	for (i = 0; i < 30; i++)

 SGSP[i].visibility = "hidden";

	for (i = 0; i < 9; i++)

 NCarSP[i].visibility = "hidden";

	for (i = 0; i < 19; i++)

 MCarSP[i].visibility = "hidden";

	for (i = 0; i < 5; i++)

 ACarSP[i].visibility = "hidden";

	for (i = 0; i < 3; i++)

 HartSP[i].visibility = "hidden";

	CntDSP.visibility = "hidden";

	MessSP.style.visibility = "hidden";

	for (i = 0; i < 2; i++){

		RTSP[i].visibility = "hidden";

		SpSP[i].visibility = "hidden";

		DGSP[i].visibility = "hidden";

	}

	for (i = 0; i < 3; i++)

 CGPSP[i].visibility = "hidden";

	for (i = 0; i < 7; i++)

 GOMessSP[i].style.visibility = "hidden";

		WSp[WhWind].visibility = "hidden";

	WhWind = 3;

	WSp[WhWind].visibility = "visible";

		TiTID = setTimeout("IntTi()", TiInt);

}

function FPMain(){

	MRoad();

		FSideG();

		FCGP();

		FNCar();

		FACar();

		FMyCar();

	SkyX -= G * Speed / 5;

	if (SkyX >= 800) SkyX -= 800;

	else if (SkyX <= -400) SkyX += 800;

	SkySP[0].left = SkyX;

	SkySP[1].left = SkyX - 800;

	t = TimeL - Math.floor(Time);

	d = Math.floor(ChkP[CNum] - Dist);

	for (i = 0; i < 2; i++){

		RTSP[i].innerText = "Time:" + t + "(s)";

		SpSP[i].innerText = "Speed:" + Speed + "(km/h)";

		DGSP[i].innerText = "Distance:" + d + "(m)";

	}

	if (t < 4){

		if (t > 0){

			WhMess = 1;

				MessC = 5;

				MessSP.innerText = t;

			MessSP.style.left = MessOx + 30;

			MessSP.style.visibility = "visible";

			}	

	else if (t <= 0){

			MessC = 0;

			GOMessSP[0].style.visibility = "visible";

			GOMessSP[6].style.visibility = "visible";

			IsTOv = 1;		}	}

	Time += PlInt / 1000;	}

function FCGP(){

	k = ChkP[CNum] - Dist;

	if (RLDis[0] > k){

		if (IsSGNUp){

			if (SGNum < 2) SGNum++;

			IsSGNUp = 0;

		}

		for (i = 0; i < 33; i++){

			if (RLDis[i] <= k) break;

		}

		if (i < 33){

			CGPSP[CNum].width = CGPS[0] = Math.floor(3300 / RLDis[i]);

			CGPSP[CNum].height = CGPS[1] = Math.floor(1000 / RLDis[i]);

			CGPSP[CNum].left = RLPx[i] - CGPS[0] / 22;

			CGPSP[CNum].top = RLCy[i] - CGPS[1];

			CGPSP[CNum].zIndex = i + 1;

				CGPSP[CNum].visibility = "visible";

		}

		else {

			if (CNum < 2){

				CGPSP[CNum].visibility = "hidden";

				CNum++;

				Time -= UpLT;	
				WhMess = 1;


						MessC = 20;

						MessSP.innerText = "+" + UpLT + "(s)";

				MessSP.style.visibility = "visible";									WSp[0].background = CCol[CNum];

					IsSGNUp = 1;				}
			else {



	if (!IsAGoal) IsGoal = 1;else IsGoal = 2;

					}
		}

	}

}

function FSideG(){

	if ((Dist + RLDis[0] - LSGP) > SGSpaP){

		for (i = 0; i < 5; i++){

			if (WhSG[i] == -1){

				if (SGSPP <= 6) SGSPP += 2;

				else SGSPP = 0;

				WhSG[i] = SGSPP + SGNum * 10;

				LSGP = SGP[i] = Dist + RLDis[0];

								break;

			}		}	}

	for (i = 0; i < 5; i++){

		if (WhSG[i] != -1){

			k = SGP[i] - Dist;

			if (RLDis[0] > k){

				for (j = 0; j < 33; j++){

					if (RLDis[j] <= k) break;

				}

				if (j < 33){


					w = Math.floor(640 / RLDis[j]);

					h = Math.floor(1280 / RLDis[j]);

					l1 = RLPx[j] - w;

					l2 = RLPx[j] + RLWid[j];

					t = RLCy[j] - h;

					SGSP[WhSG[i]].width = SGSP[WhSG[i] + 1].width = w;

					SGSP[WhSG[i]].height = SGSP[WhSG[i] + 1].height = h;

					SGSP[WhSG[i]].left = l1;

					SGSP[WhSG[i] + 1].left = l2;

					SGSP[WhSG[i]].top = SGSP[WhSG[i] + 1].top = t;

					SGSP[WhSG[i]].zIndex = SGSP[WhSG[i] + 1].zIndex = j + 1;

					SGSP[WhSG[i]].visibility = SGSP[WhSG[i] + 1].visibility = "visible";

				}

				else{

					SGSP[WhSG[i]].visibility = SGSP[WhSG[i] + 1].visibility = "hidden";

					WhSG[i] = -1;
				}			}		}	}}


function FNCar(){

	md = 0;

	for (mf = 0; mf < 3; mf++){

		if (md < NCSPD[mf]) md = NCSPD[mf];

	}

		if (Speed > NCSpd){

		if ((Dist + RLDis[0] - md) > NCSpaD){

			for (i = 0; i < 3; i++){

				if (NCSPN[i] == 9){

					n = Math.floor((Math.random() * 16) % 9);

					is_dup = 0;

					for (j = 0; j < 3; j++){

						if (NCSPN[j] == n) is_dup = 1;

					}										if (!is_dup){
						NCSPN[i] = n;

						NCSPD[i] = Dist + RLDis[0];


						NCSPPx[i] = Math.floor((Math.random() * 16) % 4);							break;
					}


				}
			}

		}

	}

		for (i = 0; i < 3; i++){

		if (NCSPN[i] != 9){

			NCSPD[i] += NCSpd / PlwI;

			k = NCSPD[i] - Dist;

			for (j = 0; j < 33; j++){

				if (RLDis[j] <= k) break;

			}

			if (j < 33 && k < 120){

				l = Math.floor(RLWid[j] / 4);

				w = h = l;

				NCSPX[i] = RLPx[j] + l * NCSPPx[i];

				t = RLCy[j] - h;

				NCSPZ[i] = j + 1;

				NCarSP[NCSPN[i]].width = w;

				NCarSP[NCSPN[i]].height = h;

				NCarSP[NCSPN[i]].left = NCSPX[i];

				NCarSP[NCSPN[i]].top = t;


				NCarSP[NCSPN[i]].zIndex = NCSPZ[i];

				NCarSP[NCSPN[i]].visibility = "visible";

			}

			else {

	NCarSP[NCSPN[i]].visibility = "hidden";

				NCSPN[i] = 9;

			}		}	}}



function FACar(){

	ACSPD += ACSpd / PlwI;

	if (ACSPD >= ChkP[2]){

		IsAGoal = 1;

		ACSpd = 0;

		}

		if (!IsACar){



		if (ACSPD < Dist + RLDis[0]){

			if (Dist + RLDis[32] < ACSPD){

				ACSPPx = Math.floor((Math.random() * 16) % 4);

				IsACar = 1;

				if (!IsAGoal) ACSpd = ACSpMid;

				ACSDx = 0;

			}

		}
	}

		if (IsACar){

		k = ACSPD - Dist;



		for (i = 0; i < 33; i++){

			if (RLDis[i] <= k) break;


		}		if (i < 33 && k < 120){

			if (!ACSDx){
				mn = -1;

					dl = 1000;

				for (j = 0; j < 3; j++){

					if (NCSPN[j] != 9){

						l = NCSPD[j] - ACSPD;

						if (-10 < l && l < dl){

							dl = l;

							mn = j;

						}

					}

				}
				if (mn != -1){

					if (NCSPPx[mn] == ACSPPx){

						if (Math.floor((Math.random() * 16) % 2)){							if (ACSPPx < 3) ACSDx = 0.25;							else ACSDx = -0.25;							}

						else{							if (ACSPPx > 0) ACSDx = -0.25;
							else ACSDx = 0.25;


							}											ACSpd = NCSpd;
						}

				}

			}

			if (ACSDx){

				ACSPPx += ACSDx;

				if (!((ACSPPx * 10) % 10)){

					ACSDx = 0;

					ACSpd = ACSpMid;

					}

			}

			l = Math.floor(RLWid[i] / 4);

			w = l;

			h = Math.floor(l / 2);

			ACSPX = RLPx[i] + l * ACSPPx;

			t = RLCy[i] - h;

			ACSPZ = i + 1;

			for (j = 0; j < 4; j++){
				ACarSP[j].width = w;

				ACarSP[j].height = h;

			}

			ACarSP[4].left = ACSPX;

			ACarSP[4].top = t;

			ACarSP[4].zIndex = ACSPZ;

			ACarSP[0].visibility = "visible";

			}

		else{

			if (i == 33) ACSpd = ACSpMax;
							ACarSP[0].visibility = "hidden";			IsACar = 0;

			}

	}

}



function FMyCar(){

	if (IsSpn){

		if (Speed >= 20) Speed -= 20;

			else Speed = 0;

		if (!Cnt){

			if (IsSpn == 1) SpnN = 1;

				else SpnN = 9;

				WhMess = 1;

				MessC = 10;

			MessSP.innerText = "Wow!!";

			MessSP.style.left = MessOx - 20;
			MessSP.style.visibility = "visible";

			}

				CMCarSP(SpnN);

			SpnN = SpnN + IsSpn;

				if ((SpnN == 0) || (SpnN == 10)){

						Cnt = 0;

			IsSpn = 0;
		}		else Cnt++;

	}

	if (!IsSpn){

		if (ON_KEY[4]){

			if (Speed < SpMax) Speed += 10;

						if (IsDrift == 1){

				IsDrift = 2;

				WhMess = 1;

					MessC = 10;

					MessSP.innerText = "Wonderful!";

				MessSP.style.left = MessOx - 100;

				MessSP.style.visibility = "visible";

				}

			if (!G) IsDrift = 0;

			}

		else if (ON_KEY[5]){

			if (Speed >= SpMax){

				if (G){

					if (ON_KEY[0] && !ON_KEY[1]){

						IsDrift = 1;

							DriftD = 0;

							}

					else if (ON_KEY[1] && !ON_KEY[0]){

						IsDrift = 1;

							DriftD = 1;

						}

				}

			}

			if (Speed >= 20) Speed -= 20;

			else Speed = 0;

						if (IsDrift == 2){

				if (Speed >= 200){

					if (DriftD) IsSpn = 1;

						else IsSpn = -1;

										Cnt = 0;

				}

							IsDrift = 0;

				}

		}	

	else{

			if (Speed >= 3) Speed -= 3;

			else Speed = 0;		

			IsDrift = 0;	
		}	

	if (ON_KEY[0] && !ON_KEY[1]){	

		if (IsDrift != 2){		

		dx = 12;			

	sp = 9;		

	}		

	else{		

		if (!DriftD){		

			dx = 32;	

				sp = 8;		

			}			

	else{					

dx = -24;				

	sp = 2;				
	}		

	}			

if (Speed){			

	MCRPx -= dx;		

		CMCarSP(sp);	
			}	

	}		

else if (ON_KEY[1] && !ON_KEY[0]){	

		if (IsDrift != 2){	

			dx = 12;	

			sp = 1;			

}		

	else{			

	if (DriftD){			
		dx = 32;		

			sp = 2;		

			}		

		else{			

		dx = -24;		

			sp = 8;		

			}		
	}			

if (Speed) MCRPx += dx;		

	if (Speed) CMCarSP(sp);		

}		

else{			

IsDrift = 0;			

	CMCarSP(0);		

	}	

}	

if ((G > 0 && 0 < MCRPx) || (G < 0 && MCRPx < 304))	

	MCRPx -= G * Speed * Speed / 2300;	

if (MCarP[0] < RLPx[30] || RLPx[30] + 318 < MCarP[0]){		

if (Speed >= 35) Speed -= 35;	

	else Speed = 0;		

IsDrift = 0;		

}	

if (!IsSpn){		

for (i = 0; i < 3; i++){	

		if (NCSPN[i] != 9){	

			if (NCSPZ[i] > 25){	

				if (MCarP[0] < NCSPX[i] + 90){		

				if (NCSPX[i] < MCarP[0] + 40){		

					if (ON_KEY[0] && !ON_KEY[1]) IsSpn = -1;		

						else IsSpn = 1;			
					Cnt = 0;			

			}	
				}		

		}			

}		}		

if (!IsSpn){		

	if (IsACar){		

		if (ACSPZ > 27){	

				if (MCarP[0] < ACSPX + 90){	

					if (ACSPX < MCarP[0] + 40){		

					if (ON_KEY[0] && !ON_KEY[1]) IsSpn = -1;	
							else IsSpn = 1;			

					Cnt = 0;					

	}				

	}				

}	
		}	

	}	

}	

Dist += Speed / PlwI;}function CMCarSP(sp){	

MCarSP[MSPN].visibility = "hidden";	

MCarSP[sp].visibility = "visible";	

	MSPN = sp;	

}



function FAnim(wh_anim){

	switch (wh_anim){

	case 1:

			CDAnim();

		break;

	case 2:

		G1Anim();

		break;

	case 3:

			G2Anim();

		break;
	}

}

function CDAnim(){

	if (!Cnt){

		CntDSP.visibility = "visible";

			ACarSP[0].visibility = "hidden";

			MCarSP[0].visibility = "hidden";

			MCarSP[10].visibility = "visible";

			mcad_p = 1;

	}

	if (!(Cnt % 7) && mcad_p < 8){		
MCarSP[MCAData[mcad_p - 1]].visibility = "hidden";			MCarSP[MCAData[mcad_p]].visibility = "visible";			

	mcad_p++;	

}	

switch (LuWData[Cnt]){	

case 0:		

LuSP[pvL].visibility = "hidden";	

		break;	

case 1:		

	WTTL();		

break;	

case 2:		

	WTTS();

		break;	
case 3:		


	WTOS();		
break;

	}	

LUCY_SP.left = LuP[0];	

LUCY_SP.top = LuP[1];	

if (!(Cnt % 10)){	

	ACarSP[3].visibility = "hidden";	

	ACarSP[1].visibility = "visible";	

}	

else if (!((Cnt + 2) % 10)){	

	ACarSP[1].visibility = "hidden";	

		ACarSP[3].visibility = "visible";	

	}	

cd = 3 - Math.floor(Cnt / 16);	

if (cd > 0){		

CNTD_SP.innerText = cd;		

Cnt++;	

}	

else{		

LuP[0] = 233;

 LuP[1] = 240;	

		LuS[0] = 16; LuS[1] = 48;	

		ACarSP[1].visibility = "hidden";	

		ACarSP[3].visibility = "hidden";	

		ACarSP[0].visibility = "visible";	

		CntDSP.visibility = "hidden";		

		Cnt = 0;				

WhAnim = 0;			

WhMess = 1;			
MessC = 20;			

MessSP.innerText = "GO";		

MessSP.style.left = MessOx;		

MessSP.style.visibility = "visible";		

			IsStart = 1;		

	ACSPD = RLDis[32] + 1;

	}

}

function WTTS(){	

ds = 1.025;		

sp = 0.5;		
MaxC = 1;	

LuS[0] *= ds;

 LuS[1] *= ds;	

k = LuS[0] / 32;	

LuP[1] += sp * k;	

	for (i = 0; i < 16; i++){	

	LuSP[i].width = LuS[0];		
LuSP[i].height = LuS[1];	

}	

LStC++;		

	if (MaxC <= LStC){	

	LuSP[pvL].visibility = "hidden";	

		if (8 <= pvL && pvL < 11) pvL++;	

	else pvL = 8;		

LuSP[pvL].visibility = "visible";	

				LStC = 0;

		}

}

function WTOS(){	

ds = 1.025;		

sp = 0.5;		

	MaxC = 1;	

LuS[0] /= ds; LuS[1] /= ds;	
k = LuS[0] / 32;	

LuP[1] -= sp * k;		

for (i = 0; i < 16; i++){	

	LuSP[i].width = LuS[0];		

LuSP[i].height = LuS[1];	

}	

LStC++;		

if (MaxC <= LStC){	

	LuSP[pvL].visibility = "hidden";	

		if (12 <= pvL && pvL < 15) pvL++;	

	else pvL = 12;		

LuSP[pvL].visibility = "visible";	
				LStC = 0;	

	}

}
function WTTL(){	

sp = 1.25;		

MaxC = 3;

	k = LuS[0] / 8;	

LuP[0] -= sp * k;	

LStC++;			

if (MaxC <= LStC){	

	LuSP[pvL].visibility = "hidden";	

		if (pvL < 3) pvL++;		

else pvL = 0;		
LuSP[pvL].visibility = "visible";	

				LStC = 0;	

	}

}
function G1Anim(){	

if (!Cnt){		

ACarSP[0].visibility = "hidden";	

		ACarSP[2].visibility = "visible";	

	}	

if (!(Cnt % 4)){	

	if (G1ACnt < 3) CMCarSP(G1AData[G1ACnt]);		

	else if (3 <= G1ACnt) hst = 1;			

		G1ACnt++;	

}	

if (hst){	
	for (i = 0; i < 3; i++){

			if (Cnt == HaAppC[i]){		

		HartSP[i].visibility = "visible";	

				IsHaApp[i] = 1;		

		}			

	if (IsHaApp[i]){			

	if (HaPy[i] > HaPyMax[i]){		

			HaPx[i] += HaDx[i];	

				HaPy[i] += HaDy[i];	

			}				

else{	HaPx[i] = 205;				

	HaPy[i] = 245;				

}						

HartSP[i].left = HaPx[i];			

	HartSP[i].top = HaPy[i];		

	}		

}	

}		

if (Cnt < 50) Cnt++;	

else{		

CMCarSP(0);		

	for (i = 0; i < 3; i++){	

		HartSP[i].visibility = "hidden";	

			IsHaApp[i] = 0;			

}		ACarSP[2].visibility = "hidden";	

	ACarSP[0].visibility = "visible";		

HaPx[0] = HaPx[1] = HaPx[2] = 205;	

	HaPy[0] = HaPy[1] = HaPy[2] = 245;	

	G1ACnt = 0;	

	hst = 0;	

	WhAnim = 0;		

Cnt = 0;	
	
IsEndA = 1;	

}

}

function G2Anim(){

	if (!Cnt){	

	ACarSP[0].visibility = "hidden";	

	ACarSP[3].visibility = "visible";	
}	

	if (Cnt < 20) Cnt++;	

else{

	ACarSP[3].visibility = "hidden";	

		ACarSP[0].visibility = "visible";	

	WhAnim = 0;		


Cnt = 0;				

IsEndA = 1;	

}

}



// -->