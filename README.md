Ideja aplikacije je mreža/platforma za ljubitelje uličnog treninga (street workout).
Korisnici mogu da se registruju, prijave, da vide druge korisnike i da se povežu sa njima, da objave svoje parkove i vide parkove koje su objavili drugi korisnici.
Uz pomoć geolocation API-a dodata je i funkcionalnost da nakon prijave korisnik na početnoj strani vidi sve objavljene parkove koji se nalaze u njegovoj blizini.

Za uloge prilikom prijave korišćen je Identity Framework, postoje dve uloge u ovom projektu, admin i user (korisnik).
Korisnik može da vrši objave parkova, editovanje i brisanje svojih parkova, takođe može i da edituje svoj profil.
Admin osim privilegija koje ima korisnik, može i da briše tuđe parkove, da edituje tuđe parkove i da obriše profile korisnika platforme.

Za rad sa bazom korišćen je Entity Framework Core i Code-First pristup. Kao program za upravljanje bazom korišćen je SQL Server Management Studio.

Implementirana je jedna funkcionalnost uz pomoć SignalR-a, a  to je prikaz koliko korisnika je trenutno na početnoj stranici.

Aplikacija je izrađena samostalno kao projekat iz predmeta Napredne .NET Tehnologije.  
