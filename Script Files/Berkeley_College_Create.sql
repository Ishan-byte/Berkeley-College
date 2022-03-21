CREATE TABLE address (
    address_id  VARCHAR2(10) NOT NULL,
    country     VARCHAR2(25) NOT NULL,
    city        VARCHAR2(25) NOT NULL,
    postal_code INTEGER NOT NULL
);

ALTER TABLE address ADD CONSTRAINT address_pk PRIMARY KEY ( address_id );

CREATE TABLE assignment (
    assignment_id   VARCHAR2(10) NOT NULL,
    assignment_type VARCHAR2(25) NOT NULL,
    department_id   VARCHAR2(10) NOT NULL,
    module_id       VARCHAR2(10) NOT NULL
);

ALTER TABLE assignment ADD CONSTRAINT assignment_pk PRIMARY KEY ( assignment_id );

CREATE TABLE departments (
    department_id   VARCHAR2(10) NOT NULL,
    department_name VARCHAR2(25) NOT NULL
);

ALTER TABLE departments ADD CONSTRAINT departments_pk PRIMARY KEY ( department_id );

CREATE TABLE module (
    module_id            VARCHAR2(10) NOT NULL,
    module_code          VARCHAR2(25) NOT NULL,
    module_name          VARCHAR2(25) NOT NULL,
    module_teaching_days INTEGER NOT NULL,
    module_credit        INTEGER NOT NULL
);

ALTER TABLE module ADD CONSTRAINT module_pk PRIMARY KEY ( module_id );

CREATE TABLE module_student (
    module_id  VARCHAR2(10) NOT NULL,
    student_id VARCHAR2(10) NOT NULL
);

ALTER TABLE module_student ADD CONSTRAINT module_student_pk PRIMARY KEY ( module_id,
                                                                          student_id );

CREATE TABLE person (
    person_id  VARCHAR2(10) NOT NULL,
    first_name VARCHAR2(25) NOT NULL,
    last_name  VARCHAR2(25) NOT NULL,
    "E-mail"   VARCHAR2(50) NOT NULL
);

ALTER TABLE person ADD CONSTRAINT person_pk PRIMARY KEY ( person_id );

CREATE TABLE person_address_info (
    person_id  VARCHAR2(10) NOT NULL,
    address_id VARCHAR2(10) NOT NULL
);

ALTER TABLE person_address_info ADD CONSTRAINT person_address_info_pk PRIMARY KEY ( person_id,
                                                                                    address_id );

CREATE TABLE result_info (
    result_id     VARCHAR2(10) NOT NULL,
    assignment_id VARCHAR2(10) NOT NULL,
    grade         VARCHAR2(5) NOT NULL,
    status        VARCHAR2(25) NOT NULL,
    student_id    VARCHAR2(10) NOT NULL
);

ALTER TABLE result_info ADD CONSTRAINT exam_info_pk PRIMARY KEY ( result_id );

CREATE TABLE student (
    person_id    VARCHAR2(10) NOT NULL,
    student_year INTEGER NOT NULL
);

ALTER TABLE student ADD CONSTRAINT student_pk PRIMARY KEY ( person_id );

CREATE TABLE student_attendence_info (
    student_id      VARCHAR2(10) NOT NULL,
    module_id       VARCHAR2(10) NOT NULL,
    attendance_date DATE NOT NULL,
    department_id   VARCHAR2(10) NOT NULL
);

ALTER TABLE student_attendence_info ADD CONSTRAINT student_attendence_info_pk PRIMARY KEY ( student_id,
                                                                                            module_id );

CREATE TABLE student_fee_payment (
    payment_id    VARCHAR2(10) NOT NULL,
    amount        INTEGER NOT NULL,
    year          INTEGER NOT NULL,
    payment_date  DATE NOT NULL,
    student_id    VARCHAR2(10) NOT NULL,
    department_id VARCHAR2(10) NOT NULL
);

ALTER TABLE student_fee_payment ADD CONSTRAINT student_fee_payment_pk PRIMARY KEY ( payment_id );

CREATE TABLE teacher (
    teacher_type VARCHAR2(25) NOT NULL,
    salary       INTEGER NOT NULL,
    person_id    VARCHAR2(10) NOT NULL
);

ALTER TABLE teacher ADD CONSTRAINT teacher_pk PRIMARY KEY ( person_id );

CREATE TABLE teacher_module_info (
    teacher_id VARCHAR2(10) NOT NULL,
    module_id  VARCHAR2(10) NOT NULL
);

ALTER TABLE teacher_module_info ADD CONSTRAINT teacher_module_info_pk PRIMARY KEY ( teacher_id,
                                                                                    module_id );

ALTER TABLE assignment
    ADD CONSTRAINT assignment_departments_fk FOREIGN KEY ( department_id )
        REFERENCES departments ( department_id );

ALTER TABLE assignment
    ADD CONSTRAINT assignment_module_fk FOREIGN KEY ( module_id )
        REFERENCES module ( module_id );

ALTER TABLE student_attendence_info
    ADD CONSTRAINT attendence_departments_fk FOREIGN KEY ( department_id )
        REFERENCES departments ( department_id );

ALTER TABLE student_attendence_info
    ADD CONSTRAINT attendence_module_fk FOREIGN KEY ( module_id )
        REFERENCES module ( module_id );

ALTER TABLE student_attendence_info
    ADD CONSTRAINT attendence_student_fk FOREIGN KEY ( student_id )
        REFERENCES student ( person_id );

ALTER TABLE result_info
    ADD CONSTRAINT exam_info_assignment_fk FOREIGN KEY ( assignment_id )
        REFERENCES assignment ( assignment_id );

ALTER TABLE module_student
    ADD CONSTRAINT module_student_module_fk FOREIGN KEY ( module_id )
        REFERENCES module ( module_id );

ALTER TABLE module_student
    ADD CONSTRAINT module_student_student_fk FOREIGN KEY ( student_id )
        REFERENCES student ( person_id );

ALTER TABLE student_fee_payment
    ADD CONSTRAINT payment_departments_fk FOREIGN KEY ( department_id )
        REFERENCES departments ( department_id );

ALTER TABLE person_address_info
    ADD CONSTRAINT person_address_info_address_fk FOREIGN KEY ( address_id )
        REFERENCES address ( address_id );

ALTER TABLE person_address_info
    ADD CONSTRAINT person_address_info_person_fk FOREIGN KEY ( person_id )
        REFERENCES person ( person_id );

ALTER TABLE result_info
    ADD CONSTRAINT result_info_student_fk FOREIGN KEY ( student_id )
        REFERENCES student ( person_id );

ALTER TABLE student_fee_payment
    ADD CONSTRAINT student_fee_payment_student_fk FOREIGN KEY ( student_id )
        REFERENCES student ( person_id );

ALTER TABLE student
    ADD CONSTRAINT student_person_fk FOREIGN KEY ( person_id )
        REFERENCES person ( person_id );

ALTER TABLE teacher_module_info
    ADD CONSTRAINT teacher_module_info_module_fk FOREIGN KEY ( module_id )
        REFERENCES module ( module_id );

ALTER TABLE teacher_module_info
    ADD CONSTRAINT teacher_module_info_teacher_fk FOREIGN KEY ( teacher_id )
        REFERENCES teacher ( person_id );

ALTER TABLE teacher
    ADD CONSTRAINT teacher_person_fk FOREIGN KEY ( person_id )
        REFERENCES person ( person_id );