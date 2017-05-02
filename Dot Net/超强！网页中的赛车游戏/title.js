<!--



verCheck = 1;

if (navigator.appName != "Microsoft Internet Explorer"	|| parseFloat(navigator.appVersion) < 3){alert("请使用Internet Explorer 4.0及以上版本！");verCheck = 0;}


function OSWnd(){subWnd = window.open("intro.htm", "", "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,width=580,height=420");}

SpTID = 0;
TiTID = 0;
SpInt = 500;
TiInt = 200;
IsL = 0;
WhWind = 3;

HAS = new Array(40, 24);
HAPx = new Array(143, 193, 243);
HAPy = new Array(80, 80, 80);
HADx = new Array(-2, 0, 2);

Ds = 1;
EnaKC = 5;
EnaCnt = 0;
oldTiInt = 0;
SelC = 0;
LCurPy = 140;


function IntSp(){
	clearTimeout(SpTID);
	if (IsL){Cnt = 0;return;}
		if (Cnt){LMessSp.visibility = "visible";Cnt = 0;}
	else{LMessSp.visibility = "hidden";Cnt = 1;}
	SpTID = setTimeout("IntSp()", SpInt);
}


function IOnL(){
	IsL = 1;SpW.style.visibility = "hidden";WSp[3].visibility = "visible";
	if (verCheck){document.onkeydown = KeyDown;document.onkeyup = KeyUp;TiTID = setTimeout("IntTi()", TiInt);}
}


function IntTi(){
	clearTimeout(TiTID);ret = 0;

	switch (WhWind){

	case 1:

		ret = FHT();

		break;

	case 2:

		ret = FOp();

		break;

	case 3:

		ret = FTi();

		break;

	}


	if (ret != WhWind){

		if (ret == 2){oldTiInt = TiInt;TiInt = PlInt;}

		else if (WhWind == 2){

			PlInt = TiInt;

			PlwI = 3600 / PlInt;

			TiInt = oldTiInt;

			Cnt = 0;

		}

				WSp[WhWind].visibility = "hidden";

		WhWind = ret;

		WSp[WhWind].visibility = "visible";

		if (WhWind == 0){

			initPlRAM();

			MRoad();

			FSideG();

			PlTID = setTimeout("IntPl()", PlInt);

			return;

		}

	}

		TiTID = setTimeout("IntTi()", TiInt);

}

function FTi(){

	ret = 3;

		if (ON_KEY[2] && !ON_KEY[3]){

		if (SelC > 0){

			TMenuSp[SelC].color = "#0000ff";

			SelC--;

			TMenuSp[SelC].color = "#ffffff";

			LCurPy -= 30;

			TMenuSp[3].top = LCurPy;

		}

	}

	else if (ON_KEY[3] && !ON_KEY[2]){

		if (SelC < 2){

			TMenuSp[SelC].color = "#0000ff";

			SelC++;

			TMenuSp[SelC].color = "#ffffff";

			LCurPy += 30;

			TMenuSp[3].top = LCurPy;

		}

	}

	else if (ON_KEY[4]) ret = SelC;

		return ret;

}

function FHT(){

	if (ON_KEY[5])

 return 3;

	else return 1;

}

function FOp(){

	if (ON_KEY[5]) return 3;

	if (!(Cnt % 16))

 Ds *= -1;

	HAS[0] += Ds;

	HAS[1] -= Ds;

	for (i = 0; i < 3; i++){

		HASP[i].width = HAS[0];

		HASP[i].height = HAS[1];

		HASP[i].left = HAPx[i] - HAS[0] / 2 + HAS[0] * HADx[i];

		HASP[i].top = HAPy[i] - HAS[1] / 2;

	}

	SetInt();

	Cnt++;

		return 2;

}function SetInt(){

	if (!EnaCnt){

		if (ON_KEY[0] && !ON_KEY[1]){

			if (pIntD > 0){

				pIntD--;

				SIntSP.innerText = IntN[pIntD];

				TiInt = IntD[pIntD];

				EnaCnt = EnaKC;

			}

		}

		else if (ON_KEY[1] && !ON_KEY[0]){

			if (pIntD < 2){

				pIntD++;

				SIntSP.innerText = IntN[pIntD];

				TiInt = IntD[pIntD];

				EnaCnt = EnaKC;

			}

		}

	}

	else

 EnaCnt--;

}



// -->