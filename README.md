# WAY - Where Are You

WAY je pùvodnì DEMO projekt, na kterém jsem si na pøelomu roku 2018 a 2019 zkoušel osvojit architekturu cloudových aplikací. Projekt jsem na rok odložil, protože poslední projekt na systému Pecom v prostøedí Amazon Cloud Services mi poskytl mnoho zkušeností, které jsem zde hledal a pochopil na nìm architekruru mikroslužeb. 

V dobì návrhu projektu mi serverless pojetí bylo stále ještì vzdálené a tak aplikace nevyužívá plného potenciálu cloudu (a použité architektonické postupy nereflektují 100% aktuální znalosti architektury mikroslužeb :-)).

Pro úèely demo projektu ho nyní pøipravují do produkèní fáze, protože vìtšina minulých projektù podléhá autorským právùm nebo dokonce utajení a pøesto bych se rád podìlil veøejnì o nìjaký ten kus zdrojáku :-)


# O Projektu

WAY *je lokalizaèní služba pro jednoduché sdílení polohy na základì sdílené URL adresy,  kterou lze skupinì osob poslat nezávisle na platformì (schùzky jednorázového charakteru, nebo veøejné události). 

WAY poskytuje po otevøené URL adresy "od pøítele" mapku s vyznaèenými body ostatních osob v dané "místnosti" èi v tzv "meetu".


## Technické øešení
Aplikaci tvoøí tøi samostatné webové služby, které si dùvìøují na základì JWT tokenu, který je zde použit prozatím pouze jako autorizanèí token (nikoliv pro  two way exchange). 

**api.petrweb.cz**
"RoomApi poskytuje základní rozhranní pro zakládání a naèítání dat z místnosti, pøijmá aktualizace polohy od clientù atp. 

Vstup do místnosti je podmínìn JWT tokenem.

**sso.petrweb.cz**
SSO Api je webová služba vydávající JTW tokeny,  kterým dùvìøuje nezávislá aplikace api.petrweb.cz. 
Token je vydán na základì tzv "Invite Url", který obsahuje zašifrovaný hash s pozvánkou.

SSO nemá závislost na databázi (pøímou ani pøes API gateway).

**way.petrweb.cz**
ASP.NET MVC projekt pro frontend (ve vývoji).

## Schéma


