<!--



Cnt = 0;

CData = new Array(10000);

ON = 1; 

OFF = 0;

ON_KEY = new Array(OFF, OFF, OFF, OFF, OFF, OFF);

function WImgTAG(id, z, x, y, w, h, gn)

{

document.write("<img ID='" + id + "' style='position:absolute;left:" + x + ";top:"		+ y + ";width:" + w + ";height:" + h + ";visibility:hidden' src='" + gn + "'>");

}

function WImgTAG2(id, gn){

	document.write("<img ID='" + id		+ "' style='position:absolute;visibility:hidden' src='" + gn + "'>");

}

function MRoad(){

	dx = new Array(33);

	k = 0;

 ulx = 0;

	for (i = 0; i < 33; i++){

		j = 32 - i;

		k = CData[Math.floor((Dist + RLDis[j]) * 3)];

		if (i == 0) G = k;

		ulx += k * i;

		dx[j] = ulx;

	}

	pos = (185 - MCRPx) * 0.05;

	for (i = 0; i < 33; i++){

		x = RLCx[i] + dx[i];

		RLPx[i] = x + (G * Speed) + (pos * i);

		RLSP[i].left = RLSP[i + 33].left = RLPx[i];

		if (((Dist + RLDis[i]) % 10) < 5){

			RLSP[i + 33].visibility = "hidden";

			RLSP[i].visibility = "visible";

		}

		else{

	RLSP[i].visibility = "hidden";

			RLSP[i + 33].visibility = "visible";

		}
	}

}

function initCData(){

	for (i = 0; i < 10000; i++) CData[i] = 0;

	midL(600, 100);

	softL(900, 100);

	midR(1500, 300);

	softL(1900, 300);

	midR(2300, 100);

	hardR(2900, 250);

	hardL(3200, 100);

	softL(3500, 300);

	softR(4000, 200);

	midL(4500, 150);

	hardR(4800, 300);

	softR(5300, 100);

	softL(5500, 200);

	midL(5800, 100);

	midR(6100, 300);

	hardL(6500, 200);

	softR(6900, 300);

	softL(7300, 200);

	hardR(7600, 150);

	midL(7900, 200);

	softL(8300, 300);

	midR(8600, 150);

}

function hardL(p, len){

	for (i = p; i < p + 10; i++)

 CData[i] = -0.1;

	for (i = p + 10; i < p + 20; i++)

 CData[i] = -0.3;

	for (i = p + 20; i < p + 20 + len; i++)

 CData[i] = -0.5;

	for (i = p + 20 + len; i < p + 30 + len; i++)

 CData[i] = -0.3;

	for (i = p + 30 + len; i < p + 40 + len; i++)

 CData[i] = -0.1;

}

function hardR(p, len)

{

	for (i = p; i < p + 10; i++)

 CData[i] = 0.1;

	for (i = p + 10;

 i < p + 20; i++)

 CData[i] = 0.3;

	for (i = p + 20; i < p + 20 + len; i++)

 CData[i] = 0.5;

	for (i = p + 20 + len; i < p + 30 + len; i++)

 CData[i] = 0.3;

	for (i = p + 30 + len; i < p + 40 + len; i++)

 CData[i] = 0.1;

}

function midL(p, len){

	for (i = p; i < p + 10; i++)

 CData[i] = -0.1;

	for (i = p + 10; i < p + 10 + len; i++)

 CData[i] = -0.3;

	for (i = p + 10 + len; i < p + 20 + len; i++)

 CData[i] = -0.1;

}

function midR(p, len){

	for (i = p; i < p + 10; i++)

 CData[i] = 0.1;

	for (i = p + 10; i < p + 10 + len; i++)

 CData[i] = 0.3;

	for (i = p + 10 + len; i < p + 20 + len; i++)

 CData[i] = 0.1;

}

function softL(p, len){

	for (i = p; i < p + len; i++)

 CData[i] = -0.1;

}

function softR(p, len){

	for (i = p; i < p + len; i++)

 CData[i] = 0.1;

}

function KeyDown(kcode){

	switch(window.event.keyCode)

	{

	case 100: case 37:

		ON_KEY[0] = ON;

		break;

	case 102: case 39:

		ON_KEY[1] = ON;

		break;

	case 104: case 38:

		ON_KEY[2] = ON;

		break;

	case 98: case 40:

		ON_KEY[3] = ON;

		break;

	case 90:

		ON_KEY[4] = ON;

		break;

	case 88:

		ON_KEY[5] = ON;

		break;

	}

}

function KeyUp(kcode){


	switch(window.event.keyCode)

	{

	case 100: case 37:

		ON_KEY[0] = OFF;

		break;

	case 102: case 39:

		ON_KEY[1] = OFF;

		break;

	case 104: case 38:

		ON_KEY[2] = OFF;

		break;

	case 98: case 40:

		ON_KEY[3] = OFF;

		break;

	case 90:

		ON_KEY[4] = OFF;

		break;

	case 88:

		ON_KEY[5] = OFF;

		break;

	}

}

function initPlRAM(){

	Cnt = 0;

	IsStart = 0;

	IsTOv = 0;

	Dist = 0;

	G = 0;

	Time = 0;

	Speed = 0;

	MSPN = 0;

	MCRPx = 218;

	IsDrift = 0;

	DriftD = 0;

	IsSpn = 0;

	SpnN = 0;

	CNum = 0;

	IsGoal = 0;

	SkyX = 0;

	for (i = 0; i < 5; i++)

 WhSG[i] = i * 2;

	SGNum = 0;

	IsSGNUp = 1;

	for (i = 0; i < 5; i++)

 SGP[i] = 20 + 20 * i;

	LSGP = 100;

	SGSPP = 8;

	for (i = 0; i < 3; i++) NCSPN[i] = 9;

	for (i = 0; i < 3; i++) NCSPD[i] = 0;

	NCLDis = 0;

	ACSpd = ACSpMid;

	ACSPPx = 1;

	ACSPX = 0;

	ACSPD = 0;

	ACSPZ = 0;

	IsACar = 1;

	ACSDx = 0;

	IsAGoal = 0;

	mcad_p = 1;

	WhMess = 0;

	LuP[0] = 233;

	LuP[1] = 240;

	LuS[0] = 16;

	LuS[1] = 48;

	LStC = 0;

	pvL = 0;

	MaxC = 2;

	for (i = 0; i < 3; i++) HaPx[i] = 205;

	for (i = 0; i < 3; i++) HaPy[i] = 245;

	for (i = 0; i < 3; i++) IsHaApp[i] = 0;

	G1ACnt = 0;

	hst = 0;

	IsEndA = 0;

	SkySP[0].left = SkyX;

	SkySP[1].left = SkyX - 800;

	for (j = 0; j < 4; j++){

		ACarSP[j].width = 96;

		ACarSP[j].height = 48;

	}

	ACarSP[4].left = 60;

	ACarSP[4].top = 245;

	ACarSP[4].zIndex = 33;

	t = TimeL - Math.floor(Time);

	d = Math.floor(ChkP[CNum] - Dist);

	for (i = 0; i < 2; i++){

		RTSP[i].innerText = "Time:" + t + "(s)";

		SpSP[i].innerText = "Speed:" + Speed + "(km/h)";

		DGSP[i].innerText = "Distance:" + d + "(m)";

	}

		WSp[0].background = CCol[CNum];

}



// -->