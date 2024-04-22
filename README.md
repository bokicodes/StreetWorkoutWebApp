# Uvodna reč

Aplikacija je izrađena samostalno kao projektni rad iz izbornog predmeta "Napredne .NET Tehnologije".
Ideja aplikacije je mreža/platforma za ljubitelje uličnog treninga (street workout). Korisnici mogu da se registruju, prijave, da vide druge korisnike i da se povežu sa njima, da objave svoje parkove i vide parkove koje su objavili drugi korisnici. Uz pomoć geolocation API-a dodata je i funkcionalnost da nakon prijave korisnik na početnoj strani vidi sve objavljene parkove koji se nalaze u njegovoj blizini.

Za uloge prilikom prijave korišćen je Identity Framework, postoje dve uloge u ovom projektu, admin i user (korisnik). Korisnik može da vrši objave parkova, editovanje i brisanje svojih parkova, takođe može i da edituje svoj profil. Admin osim privilegija koje ima korisnik, može i da briše tuđe parkove, da edituje tuđe parkove i da obriše profile korisnika platforme.

Za rad sa bazom korišćen je Entity Framework Core i Code-First pristup. Kao program za upravljanje bazom korišćen je SQL Server Management Studio.

Implementirana je jedna funkcionalnost uz pomoć SignalR-a, a to je prikaz koliko korisnika je trenutno na početnoj stranici. Glavna tehnologija korišćena u izradi projekta je ASP.NET Core.


# Početna stranica

Nakon otvaranja aplikacije korisnik nailazi na početnu stranu sledećeg izgleda:

![home_page](https://github.com/bokicodes/StreetWorkoutWebApp/assets/114671954/20671736-a377-43b0-97cb-864c883208c3)

Nakon prijave korisnik će biti u mogućnosti da vidi sve objavljene parkove koji se nalaze u njegovoj blizini:

![parks_near](https://github.com/bokicodes/StreetWorkoutWebApp/assets/114671954/10bf2160-5537-49e2-906c-01510d2ea30e)


# Registracija i pijava

Korisnik ima mogućnost da se registruje. Za proveru šifre prilikom registracije korišćeni su Data Annotations koji mogu da vrše razne provere, provere su odrađene u skladu sa „password complexity“ uslovima koji idu uz Identity Framework.

![reg](https://github.com/bokicodes/StreetWorkoutWebApp/assets/114671954/a20e376a-0b55-4d74-9b9c-16dedfd13985)

Nakon validne registracije korisnik je odveden na stranicu za prijavu:

![login](https://github.com/bokicodes/StreetWorkoutWebApp/assets/114671954/8c4c099a-2081-4bff-be35-a758e13110d1)


# Korisnički dashboard

Nakon uspešne prijave korisnik je odveden na stranicu koja prikazuje njegov Dashboard odnosno mesto na kome on može da vodi evidenciju o svojim objavljenim parkovima. To je mesto gde on može i da kreira
odnosno objavi park i da edituje svoj profil.

![dashboard_after_login](https://github.com/bokicodes/StreetWorkoutWebApp/assets/114671954/2d19a583-268e-4873-a2a2-61d995c347b2)


# Stranica „Parks“

Na stranici „Parks“ korisnik može da vidi sve objave parkova na platformi. To je takođe mesto gde admin može da edituje i briše tuđe parkove.

![park_page](https://github.com/bokicodes/StreetWorkoutWebApp/assets/114671954/d63dbcdd-fddb-4bd3-822e-49078c45aebd)

Klikom na dugme „View“ korisnik otvara posebnu stranicu u kojoj može videti detalje objave:

![view_park](https://github.com/bokicodes/StreetWorkoutWebApp/assets/114671954/0608ce5e-2caf-4996-9231-a74062b67111)


# Stranica „Users“

Na ovoj stranici korisnik može da vidi sve korisnike koji su registrovani na aplikaciji.

![users_page](https://github.com/bokicodes/StreetWorkoutWebApp/assets/114671954/6d31c2f4-fc58-42e0-8dd0-ac23b814a0eb)

Ukoliko korisnik želi da vidi detalje određenog korisnika, to može uraditi klikom na dugme „View“. Tu može videti kontakt određenog korisnika odnosno email adresu i grad i državu u kojoj se korisnik nalazi.

![user_details](https://github.com/bokicodes/StreetWorkoutWebApp/assets/114671954/3cbd4749-3aa1-4737-ab79-da228884a7eb)


# Završna reč

Izrađujući ovu aplikaciju sam naučio mnogo toga o ASP.NET Core tehnologiji i uvideo koliko je svet .NET-a zapravo dubok.
Sve ovo me je motivisalo na dalje učenje i na dalji trud.

Zahvaljujem puno svojoj mentorki Tatjani Stojanović i Vama što ste izdvojili vreme da pogledate moj rad!






