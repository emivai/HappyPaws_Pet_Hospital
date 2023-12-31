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

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/8b206bac-1531-427e-a387-e8240d8a0145)

**2.1 pav.** Sistemos HappyPaws diegimo diagrama

# 3.Naudotojo sąsajos projektas

Šiame skyriuje pateikiami projektuojamos vartotojo sąsajos wireframe'ai ir jų realizacijos langų iškarpos (3.1 – 3.16 pav.).

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/1ef58d1b-0ecb-426b-9e30-1103296e9964)

**3.1 pav.** Pradinio lango wireframe

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/8b17ad17-3cd2-466c-9787-7e1e574538ba)

**3.2 pav.** Pradinio lango realizacija

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/bf4653db-d962-48cc-8538-363d78c211b2)

**3.3 pav.** Registracijos lango wireframe

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/2cd57451-6652-4a9e-996e-45093f96e4a1)

**3.4 pav.** Registracijos lango realizacija

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/28172274-eddd-4f84-b780-a6be0a31118a)

**3.5 pav.** Prisijungimo lango wireframe

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/abec17b8-466a-4c2e-8dfe-b01ff528588c)

**3.6 pav.** Prisijungimo lango realizacija

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/d8a0f460-2303-47cf-91db-c7078fd1bde0)

**3.7 pav.** Paslaugų lango wireframe

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/47230eba-210e-4360-ab81-18c43bc00495)

**3.8 pav.** Paslaugų lango realizacija

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/06e11e4e-3987-4105-8011-59a8b93b576c)

**3.9 pav.** Gydytojų lango wireframe

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/07a2ab24-b02d-43d6-9d5a-311636f93fd8)

**3.10 pav.** Gydytojų lango realizacija

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/4313244f-71e2-4cd8-a5c2-0b0b279ad8f6)

**3.11 pav.** Augintinių lango wireframe

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/4e27b8fd-45f7-48a7-973d-6e4af0ebf09f)

**3.12 pav.** Augintinių lango realizacija

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/4cba54f2-fc30-4815-a242-335015666e43)

**3.13 pav.** Registracijų vizitams lango wireframe

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/f3e95481-126b-4948-b562-2a9016f8a896)

**3.14 pav.** Registracijų vizitams lango realizacija

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/772c46eb-f092-4454-a25f-f47afa430fbb)

**3.15 pav.** Gydytojų darbo laikų lango wireframe

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/ba65520b-a3d6-43e8-998a-bcba4f8943aa)

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

Šiame skyriuje pateikiami visų metodų naudojimo pavyzdžiai naudojantis Swagger vartotojo sąsaja (4.1 – 4.38 pav.). Kiekviename paveikslėlyje matoma, kokia buvo užklausa ir koks statuso kodas bei atsako turinys grįžo.

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/409d2b9d-43e4-4684-85d0-780eb1c88e31)

**4.1 pav.** AppointmentProcedures GET metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/c065f780-d549-414d-9eef-618ff0ffa6b9)

**4.2 pav.** AppointmentProcedures POST metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/fe703a7e-0c34-433e-baed-febefa266e51)

**4.3 pav.** AppointmentProcedures GET pagal id metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/eff7a0aa-dfba-400e-b506-cbbf53b3a3be)

**4.4 pav.** AppointmentProcedures PUT metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/5961d39d-dec6-4e2a-95aa-7bd8702703cc)

**4.5 pav.** AppointmentProcedures DELETE metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/1150beb7-dba5-46ba-87b3-4010e0fc03ab)

**4.6 pav.** Appointment GET metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/bd1544dd-8a79-468d-9e91-a0917c3af67a)

**4.7 pav.** Appointment POST metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/f16b961a-dad0-429c-8d33-086198f90d3c)

**4.8 pav.** Appointment GET pagal id metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/a3089390-4676-40bf-9946-cb67e75aa73b)

**4.9 pav.** Appointment PUT metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/5e165087-21e8-4079-870f-e0ba4297b93c)

**4.10 pav.** Appointment DELETE metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/e8512935-c7ec-4c3e-a262-cd9ef276e798)

**4.11 pav.** Auth prisijungimo metodas (POST)

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/deae9326-5c2e-464a-aff7-41c249913299)

**4.12 pav.** Auth registracijos metodas (POST)

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/dc052ca4-ee6a-4a54-8704-07d0d14dc54b)

**4.13 pav.** Auth dabartinio prisijungusio vartotojo metodas (GET)

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/14527ed8-8217-4685-8fc5-519e2de11ad4)

**4.14 pav.** Auth atsijungimo metodas (POST)

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/751e6f4a-93ef-4677-aedc-eb8596c3a30a)

**4.15 pav.** Note GET metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/57706b55-98bd-4efe-ba7f-1be3bdb18cee)

**4.16 pav.** Note POST metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/c5058705-22ed-478b-9a9f-513738b6ec84)

**4.17 pav.** Note GET pagal id metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/89bf7b6c-8343-458b-aa44-9dda5847c34f)

**4.18 pav.** Note PUT metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/8992d147-43eb-4e0a-889d-14f4e296ff27)

**4.19 pav.** Note DELETE metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/51a8a86c-d9d0-4099-8ff3-7077feadc049)

**4.20 pav.** Pet GET metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/d90f067a-a087-453d-8ab8-dd1026aafa44)

**4.21 pav.** Pet POST metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/86aa1485-7477-400c-b3e8-736fa752317b)

**4.22 pav.** Pet GET pagal id metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/ba5b712b-1653-4202-a566-50ee89918cb5)

**4.23 pav.** Pet PUT metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/42d8f10d-0d87-4e36-9037-0c1698f49179)

**4.24 pav.** Pet DELETE metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/a39f0f42-6872-48e8-aef4-1f278ae29fc0)

**4.25 pav.** Procedure GET metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/f1dba775-59a2-42cf-bc38-d8419559d215)
 **4.26 pav.** Procedure POST metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/a3f74e23-f7b5-44bc-8ae2-bf321fdffb12)

**4.27 pav.** Procedure GET pagal id metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/3d58b09c-737c-4427-8afa-3770c67823d2)

**4.28 pav.** Procedure PUT metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/d55ca363-0b0e-45ba-9c6a-da1092ea88f2)

**4.29 pav.** Procedure DELETE metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/07672505-f09a-4135-85c3-0a8d4ce0c806)
 **4.30 pav.** Timeslot GET metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/af744d2a-1619-4b93-b2d2-eddcc7653c0e)

**4****.31 pav**. Timeslot POST metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/d648d013-f194-43f3-ad0f-76a58c52a74b)

**4****.32 pav**. Timeslot GET pagal id metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/5b0b9325-d4cc-4771-b0ab-921f23e09331)

**4****.33 pav**. Timeslot PUT metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/5c98c3a6-f607-4305-abf6-f5ab4fa741df)

**4****.34 pav**. Timeslot DELETE metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/572f89e3-ca8d-4667-875e-242cf18ca124)
**4****.35 pav.** User GET pagal id metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/0463c938-e0c8-4eca-a284-3bc0c9e4cd6e)

**4****.36 pav.** User GET metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/af33c601-a45d-42d4-8f01-34097e3b9cc6)

**4****.37 pav.** User PUT metodas

![image](https://github.com/emivai/happy-paws-pet-hospital/assets/83002035/d1dd14d0-8d0f-4ebe-b474-9f2c69086700)

**4****.38 pav.** User DELETE metodas

# 5.Išvados

Šis projektas nebuvo mano pirmas bandymas kurti API su .NET karkasu, tačiau jo metu labiau pasigilinau ir išmokau naujų dalykų. Pavyzdžiui, sužinojau, jog situacijose, kur užklausos duomenys tinkamo formato, tačiau nepraeina specifinės sistemos loginės validacijos teisingiau grąžinti statuso kodą 422, kuris reiškia, jog užklausa suprasta, tačiau atsisakoma įvykdyti, o anksčiau būčiau naudojusi statuso kodą 400. Anksčiau neteko implementuoti autorizacijos su refresh token, tai irgi naujai įgauta patirtis.

Didžiausias iššūkis man buvo vartotojo sąsajos kūrimas, nes nebuvau naudojusi React karkaso ir apskritai su šia sritimi mažai dirbusi. Lyginant su paprasčiausiu HTML, man patiko galimybė kurti pernaudojamus komponentus, dėl kurių kodas daug švaresnis, nei daug kartų panašaus elemento pakartojimas.

Apibendrinant, galiu teigti, jog Saitynų taikomųjų programų projektavimo modulio laboratorinių darbų metu sukurtos sistemos HappyPaws patirtis buvo įdomi ir suteikė prasmingų specialybinių žinių.
