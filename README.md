# WAY - Where Are You

WAY je p�vodn� DEMO projekt, na kter�m jsem si na p�elomu roku 2018 a 2019 zkou�el osvojit architekturu cloudov�ch aplikac�. Projekt jsem na rok odlo�il, proto�e posledn� projekt na syst�mu Pecom v prost�ed� Amazon Cloud Services mi poskytl mnoho zku�enost�, kter� jsem zde hledal a pochopil na n�m architekruru mikroslu�eb. 

V dob� n�vrhu projektu mi serverless pojet� bylo st�le je�t� vzd�len� a tak aplikace nevyu��v� pln�ho potenci�lu cloudu (a pou�it� architektonick� postupy nereflektuj� 100% aktu�ln� znalosti architektury mikroslu�eb :-)).

Pro ��ely demo projektu ho nyn� p�ipravuj� do produk�n� f�ze, proto�e v�t�ina minul�ch projekt� podl�h� autorsk�m pr�v�m nebo dokonce utajen� a p�esto bych se r�d pod�lil ve�ejn� o n�jak� ten kus zdroj�ku :-)


# O Projektu

WAY *je lokaliza�n� slu�ba pro jednoduch� sd�len� polohy na z�klad� sd�len� URL adresy,  kterou lze skupin� osob poslat nez�visle na platform� (sch�zky jednor�zov�ho charakteru, nebo ve�ejn� ud�losti). 

WAY poskytuje po otev�en� URL adresy "od p��tele" mapku s vyzna�en�mi body ostatn�ch osob v dan� "m�stnosti" �i v tzv "meetu".


## Technick� �e�en�
Aplikaci tvo�� t�i samostatn� webov� slu�by, kter� si d�v��uj� na z�klad� JWT tokenu, kter� je zde pou�it prozat�m pouze jako autorizan�� token (nikoliv pro  two way exchange). 

**api.petrweb.cz**
"RoomApi poskytuje z�kladn� rozhrann� pro zakl�d�n� a na��t�n� dat z m�stnosti, p�ijm� aktualizace polohy od client� atp. 

Vstup do m�stnosti je podm�n�n JWT tokenem.

**sso.petrweb.cz**
SSO Api je webov� slu�ba vyd�vaj�c� JTW tokeny,  kter�m d�v��uje nez�visl� aplikace api.petrweb.cz. 
Token je vyd�n na z�klad� tzv "Invite Url", kter� obsahuje za�ifrovan� hash s pozv�nkou.

SSO nem� z�vislost na datab�zi (p��mou ani p�es API gateway).

**way.petrweb.cz**
ASP.NET MVC projekt pro frontend (ve v�voji).

## Sch�ma


