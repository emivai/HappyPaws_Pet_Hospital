CREATE TABLE users (
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	type int,
	name VARCHAR NOT NULL,
	surname VARCHAR NOT NULL,
	email VARCHAR NOT NULL,
	phone_number VARCHAR NOT NULL
);

ALTER TABLE users  
   ADD CONSTRAINT check_types 
   CHECK (type IN (0, 1) );

CREATE TABLE doctors (
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	name VARCHAR NOT NULL,
	surname VARCHAR NOT NULL,
	email VARCHAR NOT NULL,
	phone_number VARCHAR NOT null,
	description VARCHAR,
	photo VARCHAR
);

CREATE TABLE procedures (
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	name VARCHAR NOT NULL,
	description VARCHAR not null,
	price decimal not null
);

CREATE TABLE pets (
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	type int NOT NULL,
	name VARCHAR NOT NULL,
	birth_date timestamptz not null,
	photo VARCHAR,
	owner_id uuid not null,
   	CONSTRAINT fk_owner FOREIGN KEY(owner_id) REFERENCES users(id) 
);

ALTER TABLE pets
   ADD CONSTRAINT check_types 
   CHECK (type IN (0, 1, 2, 3) );
  
CREATE TABLE time_slots (
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	beginning timestamptz not null,
	ending timestamptz not null,
	available bool not null,
	doctor_id uuid not null,
   	CONSTRAINT fk_doctor FOREIGN KEY(doctor_id) REFERENCES doctors(id) 
);  

CREATE UNIQUE INDEX idx_time_slot_beginning_ending_doctor
ON time_slots(beginning, ending, doctor_id);

CREATE TABLE appointments (
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	price decimal not null,
	status int not null,
	pet_id uuid not null,
	time_slot_id uuid not null,
   	CONSTRAINT fk_pet FOREIGN KEY(pet_id) REFERENCES pets(id), 
   	CONSTRAINT fk_time_slot FOREIGN KEY(time_slot_id) REFERENCES time_slots(id)
); 

ALTER TABLE appointments
   ADD CONSTRAINT check_types 
   CHECK (status IN (0, 1) );

CREATE TABLE notes (
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	value varchar not null,
	appointment_id uuid not null,
   	CONSTRAINT fk_appointment FOREIGN KEY(appointment_id) REFERENCES appointments(id) 
); 

CREATE TABLE appointment_procedures (
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	procedure_id uuid not null,
	appointment_id uuid not null,
   	CONSTRAINT fk_procedure FOREIGN KEY(procedure_id) REFERENCES procedures(id),
	CONSTRAINT fk_appointment FOREIGN KEY(appointment_id) REFERENCES appointments(id)
);

CREATE UNIQUE INDEX idx_appointment_procedure_procedure_appointment
ON appointment_procedures(procedure_id, appointment_id);