# Happy Paws Pet Hospital

**KAUNO TECHNOLOGIJOS UNIVERSITETAS**

**INFORMATIKOS FAKULTETAS**

**Modulio T120B165 „Saityno taikomųjų programų projektavimas"**

Laboratorinio darbo aprašas (ataskaita)

**Projekto „Happy Paws Pet Hospital" ataskaita**

**Dėstytojas** dėst.val. Baltulionis Simonas dėst.val. Lukošius Tomas

**Studentas** Emilija Vaisvalavičiūtė IFF-0/2

**KAUNAS, 2023**

# Turinys

[1. Sprendžiamo uždavinio aprašymas 3](#_Toc154931456)

[1.1. Sistemos paskirtis 3](#_Toc154931457)

[1.2. Funkciniai reikalavimai 3](#_Toc154931458)

[2. Sistemos architektūra 5](#_Toc154931459)

[3. Naudotojo sąsajos projektas 6](#_Toc154931460)

[4. API specifikacija 14](#_Toc154931461)

[4.1. Markdown specifikacija 14](#_Toc154931462)

[4.2. Naudojimo pavyzdžiai 22](#_Toc154931463)

[5. Išvados 36](#_Toc154931464)

# 1.Sprendžiamo uždavinio aprašymas

## 1.1.Sistemos paskirtis

Projekto tikslas – suteikti veterinarijos klinikai bei jos klientams elektroninį įrankį palengvinantį tarpusavio komunikaciją ir paslaugų teikimą.

Veikimo principas – platformą sudaro serverio dalis, aplikacijų programavimo sąsaja (angl. API), ir kliento sąsaja, skirta naudotojams.

Klinikos klientas, norėdamas naudotis šia platforma, prisiregistruos prie internetinės aplikacijos ir galės valdyti savo augintinių medicinines paskyras, registruoti vizitams pas gydytojus. Gydytojai prisiregistruos prie internetinės aplikacijos, o tuomet pridės ir redaguos savo darbo laikus, galės peržiūrėti pacientų profilius ir registracijas, palikti komentarus. Administratorius valdys sistemoje pateikiamą informaciją apie klinikoje teikiamas paslaugas bei turės prieigą prie visų anksčiau paminėtų kitų rolių funkcijų.

## 1.2.Funkciniai reikalavimai

Neprisijungęs naudotojas galės:

1. Peržiūrėti sistemos reprezentacinį puslapį
2. Užsiregistruoti
3. Prisijungti prie savo paskyros

Betkurios rolės prisijungęs vartotojas galės:

1. Redaguoti savo paskyros duomenis
2. Ištrinti savo paskyrą
3. Atsijungti

Klientas galės:

1. Valdyti savo augintinių profilius:
  1. Pridėti augintinį
  2. Redaguoti augintinio informaciją
  3. Ištrinti augintinio profilį
  4. Peržiūrėti augintinių profilius
2. Peržiūrėti gydytojų darbo tvarkaraščius
3. Peržiūrėti klinikos paslaugas
4. Registruoti augintinį vizitui pas gydytoją
5. Palikti komentarą vizitui

Gydytojas galės:

1. Valdyti savo darbo laikus:
  1. Pridėti darbo laiką
  2. Redaguoti darbo laiką
  3. Ištrinti darbo laiką
  4. Peržiūrėti darbo laikus
2. Peržiūrėti savo pacientų profilius
3. Peržiūrėti savo pacientų registracijas
4. Peržiūrėti klinikos paslaugas
5. Palikti komentarą vizitui
6. Atsijungti

Administratorius galės:

1. Valdyti klinikos paslaugų informaciją:
  1. Pridėti paslaugą
  2. Redaguoti paslaugą
  3. Ištrinti paslaugą
  4. Peržiūrėti paslaugas
2. Atlikti viską, ką gali klientas bei gydytojas, tačiau matys visus sistemos augintinius, vizitus ir t.t., ne tik savo

# 2.Sistemos architektūra

Sistemos sudedamosios dalys:

• Kliento pusė (ang. Front-End) – naudojant React.js;

• Serverio pusė (angl. Back-End) – naudojant .NET Core. Duomenų bazė – PostgreSQL.

2.1 pav. pavaizduota kuriamos sistemos diegimo diagrama. Sistemos talpinimui yra naudojamas Azure serveris. Kiekviena sistemos dalis yra diegiama tame pačiame serveryje. Internetinė aplikacija yra pasiekiama per HTTP protokolą. Šios sistemos veikimui (pvz., duomenų manipuliavimui su duomenų baze) yra reikalingas HappyPaws API, kuris pasiekiamas per aplikacijų programavimo sąsają. Pats HappyPaws API vykdo duomenų mainus su duomenų baze - tam naudojama ORM sąsaja.

![](RackMultipart20231231-1-313xqn_html_2b6ae7087d087e0c.png)

**2.1 pav.** Sistemos HappyPaws diegimo diagrama

# 3.Naudotojo sąsajos projektas

Šiame skyriuje pateikiami projektuojamos vartotojo sąsajos wireframe'ai ir jų realizacijos langų iškarpos (3.1 – 3.16 pav.).

![](RackMultipart20231231-1-313xqn_html_fec0534770b57e52.png)

**3.1 pav.** Pradinio lango wireframe

![](RackMultipart20231231-1-313xqn_html_c5086008b80f6f3d.png)

**3.2 pav.** Pradinio lango realizacija

![](RackMultipart20231231-1-313xqn_html_e434aa4f6db86ca6.png)

**3.3 pav.** Registracijos lango wireframe

![](RackMultipart20231231-1-313xqn_html_3110da6b8032049e.png)

**3.4 pav.** Registracijos lango realizacija

![](RackMultipart20231231-1-313xqn_html_44d2770eba53d2ec.png)

**3.5 pav.** Prisijungimo lango wireframe

![](RackMultipart20231231-1-313xqn_html_f4f577621c4f786d.png)

**3.6 pav.** Prisijungimo lango realizacija

![](RackMultipart20231231-1-313xqn_html_f2af4780046eebb9.png)

**3.7 pav.** Paslaugų lango wireframe

![](RackMultipart20231231-1-313xqn_html_e736113d67b8e0db.png)

**3.8 pav.** Paslaugų lango realizacija

![](RackMultipart20231231-1-313xqn_html_c0f5ba60c731a568.png)

**3.9 pav.** Gydytojų lango wireframe

![](RackMultipart20231231-1-313xqn_html_6d2233341503bfe9.png)

**3.10 pav.** Gydytojų lango realizacija

![](RackMultipart20231231-1-313xqn_html_d1d9ba6e203618c8.png)

**3.11 pav.** Augintinių lango wireframe

![](RackMultipart20231231-1-313xqn_html_6a398fbe27f08e63.png)

**3.12 pav.** Augintinių lango realizacija

![](RackMultipart20231231-1-313xqn_html_33784543d311fc16.png)

**3.13 pav.** Registracijų vizitams lango wireframe

![](RackMultipart20231231-1-313xqn_html_ba8a6227ec03d6d.png)

**3.14 pav.** Registracijų vizitams lango realizacija

![](RackMultipart20231231-1-313xqn_html_f2af4780046eebb9.png)

**3.15 pav.** Gydytojų darbo laikų lango wireframe

![](RackMultipart20231231-1-313xqn_html_86115679fc8ca140.png)

**3.16 pav.** Gydytojų darbo laikų lango realizacija

# 4.API specifikacija

## 4.1.Markdown specifikacija

Šiame skyriuje OpenAPI specifikacija pateikiama konvertuota į markdown stilių, jog būtų lengviau skaitoma. Kiekvienam metodui pateikti galimi statuso kodai.

# HappyPaws.API

## Version: 1.0

### /Appointments/{appointmentId}/AppointmentProcedures

#### GET

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| appointmentId | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 400 | Bad Request |

#### POST

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| appointmentId | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 201 | Created |

| 400 | Bad Request |

| 422 | Client Error |

### /Appointments/{appointmentId}/AppointmentProcedures/{id}

#### GET

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| appointmentId | path | | Yes | string (uuid) |

| id | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 404 | Not Found |

#### PUT

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| appointmentId | path | | Yes | string (uuid) |

| id | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 400 | Bad Request |

| 404 | Not Found |

| 422 | Client Error |

#### DELETE

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| appointmentId | path | | Yes | string (uuid) |

| id | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 204 | No Content |

| 400 | Bad Request |

| 404 | Not Found |

### /Pets/{petId}/Appointments

#### GET

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| petId | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 400 | Bad Request |

#### POST

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| petId | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 201 | Created |

| 400 | Bad Request |

| 422 | Client Error |

### /Pets/{petId}/Appointments/{appointmentId}

#### GET

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| petId | path | | Yes | string (uuid) |

| appointmentId | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 400 | Bad Request |

#### PUT

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| petId | path | | Yes | string (uuid) |

| appointmentId | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 400 | Bad Request |

| 404 | Not Found |

| 422 | Client Error |

#### DELETE

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| petId | path | | Yes | string (uuid) |

| appointmentId | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 204 | No Content |

| 400 | Bad Request |

| 404 | Not Found |

### /auth/login

#### POST

##### Responses

| Code | Description |

| ---- | ----------- |

| 400 | Bad Request |

### /auth/register

#### POST

##### Responses

| Code | Description |

| ---- | ----------- |

| 201 | Created |

| 400 | Bad Request |

| 422 | Client Error |

### /auth/currentUser

#### GET

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

### /auth/logout

#### POST

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

### /Pets/{petId}/Appointments/{appointmentId}/Notes

#### GET

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| petId | path | | Yes | string (uuid) |

| appointmentId | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 400 | Bad Request |

#### POST

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| petId | path | | Yes | string (uuid) |

| appointmentId | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 201 | Created |

| 400 | Bad Request |

| 422 | Client Error |

### /Pets/{petId}/Appointments/{appointmentId}/Notes/{noteId}

#### GET

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| petId | path | | Yes | string (uuid) |

| appointmentId | path | | Yes | string (uuid) |

| noteId | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 400 | Bad Request |

#### PUT

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| petId | path | | Yes | string (uuid) |

| appointmentId | path | | Yes | string (uuid) |

| noteId | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 400 | Bad Request |

| 404 | Not Found |

| 422 | Client Error |

#### DELETE

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| petId | path | | Yes | string (uuid) |

| appointmentId | path | | Yes | string (uuid) |

| noteId | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 204 | No Content |

| 400 | Bad Request |

| 404 | Not Found |

### /Pets

#### GET

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 400 | Bad Request |

#### POST

##### Responses

| Code | Description |

| ---- | ----------- |

| 201 | Created |

| 400 | Bad Request |

| 422 | Client Error |

### /Pets/{id}

#### GET

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| id | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 404 | Not Found |

#### PUT

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| id | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 400 | Bad Request |

| 404 | Not Found |

| 422 | Client Error |

#### DELETE

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| id | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 204 | No Content |

| 400 | Bad Request |

| 404 | Not Found |

### /Procedures

#### GET

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 400 | Bad Request |

#### POST

##### Responses

| Code | Description |

| ---- | ----------- |

| 201 | Created |

| 400 | Bad Request |

| 422 | Client Error |

### /Procedures/{id}

#### GET

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| id | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 404 | Not Found |

#### PUT

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| id | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 400 | Bad Request |

| 404 | Not Found |

| 422 | Client Error |

#### DELETE

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| id | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 204 | No Content |

| 400 | Bad Request |

| 404 | Not Found |

### /TimeSlots

#### GET

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| doctorId | query | | No | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 400 | Bad Request |

#### POST

##### Responses

| Code | Description |

| ---- | ----------- |

| 201 | Created |

| 400 | Bad Request |

| 422 | Client Error |

#### DELETE

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| id | query | | No | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 204 | No Content |

| 400 | Bad Request |

| 404 | Not Found |

### /TimeSlots/{id}

#### GET

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| id | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 404 | Not Found |

#### PUT

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| id | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 400 | Bad Request |

| 404 | Not Found |

| 422 | Client Error |

### /Users

#### GET

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| type | query | | No | [UserType](#UserType) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 400 | Bad Request |

#### DELETE

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| id | query | | No | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 204 | No Content |

| 400 | Bad Request |

| 404 | Not Found |

### /Users/{id}

#### GET

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| id | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 404 | Not Found |

#### PUT

##### Parameters

| Name | Located in | Description | Required | Schema |

| ---- | ---------- | ----------- | -------- | ---- |

| id | path | | Yes | string (uuid) |

##### Responses

| Code | Description |

| ---- | ----------- |

| 200 | Success |

| 400 | Bad Request |

| 404 | Not Found |

| 422 | Client Error |

## 4.2.Naudojimo pavyzdžiai

Šiame skyriuje pateikiami visų metodų naudojimo pavyzdžiai naudojantis Swagger vartotojo sąsaja (4.1 – 4.37 pav.). Kiekviename paveikslėlyje matoma, kokia buvo užklausa ir koks statuso kodas bei atsako turinys grįžo.

![](RackMultipart20231231-1-313xqn_html_386587925bf15ecd.png)

**4.1 pav.** AppointmentProcedures GET metodas

![](RackMultipart20231231-1-313xqn_html_2d850d5716918114.png)

**4.2 pav.** AppointmentProcedures POST metodas

![](RackMultipart20231231-1-313xqn_html_3edacf47c13c973f.png)

**4.3 pav.** AppointmentProcedures GET pagal id metodas

![](RackMultipart20231231-1-313xqn_html_3dbc9ea13eb0fda9.png)

**4.4 pav.** AppointmentProcedures PUT metodas

![](RackMultipart20231231-1-313xqn_html_67891b7749f80c60.png)

**4.5 pav.** AppointmentProcedures DELETE metodas

![](RackMultipart20231231-1-313xqn_html_edc4e96f08d03cc4.png)

**4.6 pav.** Appointment GET metodas

![](RackMultipart20231231-1-313xqn_html_20742bddb691a012.png)

**4.7 pav.** Appointment POST metodas

![](RackMultipart20231231-1-313xqn_html_450bc8b64766871f.png)

**4.8 pav.** Appointment GET pagal id metodas

![](RackMultipart20231231-1-313xqn_html_c9da2e6f8dabf404.png)

**4.9 pav.** Appointment PUT metodas

![](RackMultipart20231231-1-313xqn_html_d83698ea77e9b0e9.png)

**4.10 pav.** Appointment DELETE metodas

![](RackMultipart20231231-1-313xqn_html_91a1882857274532.png)

**4.11 pav.** Auth prisijungimo metodas (POST)

![](RackMultipart20231231-1-313xqn_html_b984f9fef1b99c.png)

**4.12 pav.** Auth registracijos metodas (POST)

![](RackMultipart20231231-1-313xqn_html_b070594983b73d92.png)

**4.13 pav.** Auth dabartinio prisijungusio vartotojo metodas (GET)

![](RackMultipart20231231-1-313xqn_html_409457a8bc078f89.png)

**4.14 pav.** Auth atsijungimo metodas (POST)

![](RackMultipart20231231-1-313xqn_html_652b64aabd7e98ba.png)

**4.15 pav.** Note GET metodas

![](RackMultipart20231231-1-313xqn_html_a900032501176ecc.png)

**4.16 pav.** Note POST metodas

![](RackMultipart20231231-1-313xqn_html_cafa2b3534b7facb.png)

**4.17 pav.** Note GET pagal id metodas

![](RackMultipart20231231-1-313xqn_html_772e423ad0209361.png)

**4.18 pav.** Note PUT metodas

![](RackMultipart20231231-1-313xqn_html_7d987bf8bebc701b.png)

**4.19 pav.** Note DELETE metodas

![](RackMultipart20231231-1-313xqn_html_fc6c4429311650d1.png)

**4.20 pav.** Pet GET metodas

![](RackMultipart20231231-1-313xqn_html_dff9673b350b4b7b.png)

**4.21 pav.** Pet POST metodas

![](RackMultipart20231231-1-313xqn_html_ffef89e10b5ee9bc.png)

**4.22 pav.** Pet GET pagal id metodas

![](RackMultipart20231231-1-313xqn_html_61090e0570b9c4ec.png)

**4.23 pav.** Pet PUT metodas

![](RackMultipart20231231-1-313xqn_html_83a24cf66c75200c.png)

**4.24 pav.** Pet DELETE metodas

![](RackMultipart20231231-1-313xqn_html_6338731e079e8beb.png)

**4.25 pav.** Procedure GET metodas

![](RackMultipart20231231-1-313xqn_html_1832e6b15b58e6c.png) **4.26 pav.** Procedure POST metodas

![](RackMultipart20231231-1-313xqn_html_554176413432a1a1.png)

**4.27 pav.** Procedure GET pagal id metodas

![](RackMultipart20231231-1-313xqn_html_d9f99ab08e2d3e90.png)

**4.28 pav.** Procedure PUT metodas

![](RackMultipart20231231-1-313xqn_html_c06dd190a3e43eca.png)

**4.29 pav.** Procedure DELETE metodas

![](RackMultipart20231231-1-313xqn_html_6c0832cfa6b5683b.png) **4.30 pav.** Timeslot GET metodas

![](RackMultipart20231231-1-313xqn_html_a1a96c749ac93c36.png)

**4****.31 pav**. Timeslot POST metodas

![](RackMultipart20231231-1-313xqn_html_db2ec6bbdc5021b2.png)

**4****.32 pav**. Timeslot GET pagal id metodas

![](RackMultipart20231231-1-313xqn_html_c36045e1320d5b68.png)

**4****.33 pav**. Timeslot PUT metodas

![](RackMultipart20231231-1-313xqn_html_151a09d32e82cc41.png)

**4****.34 pav**. Timeslot DELETE metodas

![](RackMultipart20231231-1-313xqn_html_efd930298247c2d7.png)

![](RackMultipart20231231-1-313xqn_html_fef637032dcf602d.png)

**4****.35 pav.** Timeslot GET metodas

![](RackMultipart20231231-1-313xqn_html_df9197a4da99f5c0.png)

**4****.36 pav.** Timeslot PUT metodas

![](RackMultipart20231231-1-313xqn_html_2d41f0e9667e95e9.png)

**4****.37 pav.** Timeslot DELETE metodas

# 5.Išvados

Šis projektas nebuvo mano pirmas bandymas kurti API su .NET karkasu, tačiau jo metu labiau pasigilinau ir išmokau naujų dalykų. Pavyzdžiui, sužinojau, jog situacijose, kur užklausos duomenys tinkamo formato, tačiau nepraeina specifinės sistemos loginės validacijos teisingiau grąžinti statuso kodą 422, kuris reiškia, jog užklausa suprasta, tačiau atsisakoma įvykdyti, o anksčiau būčiau naudojusi statuso kodą 400. Anksčiau neteko implementuoti autorizacijos su refresh token, tai irgi naujai įgauta patirtis.

Didžiausias iššūkis man buvo vartotojo sąsajos kūrimas, nes nebuvau naudojusi React karkaso ir apskritai su šia sritimi mažai dirbusi. Lyginant su paprasčiausiu HTML, man patiko galimybė kurti pernaudojamus komponentus, dėl kurių kodas daug švaresnis, nei daug kartų panašaus elemento pakartojimas.

Apibendrinant, galiu teigti, jog Saitynų taikomųjų programų projektavimo modulio laboratorinių darbų metu sukurtos sistemos HappyPaws patirtis buvo įdomi ir suteikė prasmingų specialybinių žinių.
