# WAY - Where Are You

WAY je původně DEMO projekt, na kterém jsem si na přelomu roku 2018 a 2019 zkoušel osvojit architekturu cloudových aplikací. Projekt jsem na rok odložil, protože poslední projekt na systému Pecom v prostředí Amazon Cloud Services mi poskytl mnoho zkušeností, které jsem zde hledal a pochopil na něm architekruru mikroslužeb. 

V době návrhu projektu mi serverless pojetí bylo stále ještě vzdálené a tak aplikace nevyužívá plného potenciálu cloudu (a použité architektonické postupy nereflektují 100% aktuální znalosti architektury mikroslužeb :-)).

Pro účely demo projektu ho nyní připravují do produkční fáze, protože většina minulých projektů podléhá autorským právům nebo dokonce utajení a přesto bych se rád podělil veřejně o nějaký ten kus zdrojáku :-)

Adresa aplikace https://way.petrweb.cz/

# O Projektu

WAY je lokalizační služba určená pro jednoduché sdílení polohy na základě jednorázového odkazu, který lze poslat skupině osob nezávisle na platformě (schůzky jednorázového charakteru, nebo veřejné události, nebo Vašim přáteům napříč komunikačními kanály).

WAY poskytuje po otevření odkazu od přítele mapku s vyznačenými body ostatních osob v daném setkání (meetu).

## Autor
**Petr Svoboda**  - 
[www.petrweb.cz](http://petrweb.cz/)

## Technické řešení
Aplikaci tvoří tři samostatné webové služby, které si důvěřují na základě JWT tokenu, který je zde použit prozatím pouze jako autorizančí token (nikoliv pro  two way exchange). 

**api.petrweb.cz** 
"MeetApi poskytuje základní rozhranní pro zakládání a načítání dat z místnosti, přijmá aktualizace polohy od clientů atp. 

Vstup do místnosti je podmíněn JWT tokenem.

API dokumentace: [https://api.petrweb.cz/swagger](https://api.petrweb.cz/swagger)

**sso.petrweb.cz**
SSO Api je webová služba vydávající JTW tokeny,  kterým důvěřuje nezávislá aplikace api.petrweb.cz. 
Token je vydán na základě tzv "Invite Url", který obsahuje zašifrovaný hash s pozvánkou.

SSO nemá závislost na databázi (přímou ani přes API gateway).

API dokumentace: [https://sso.petrweb.cz/swagger](https://sso.petrweb.cz/swagger) 

**way.petrweb.cz**
ASP.NET MVC projekt pro frontend (ve vývoji).

## Schéma
[https://petrweb.cz/images/diagram.jpg](https://petrweb.cz/images/diagram.jpg)

![enter image description here](http://petrweb.cz/images/diagram.jpg)
