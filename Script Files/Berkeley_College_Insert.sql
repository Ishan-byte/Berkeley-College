insert into address values('Add1','Nepal','Kathmandu', 44600);
insert into address values('Add2','India','Delhi', 66000);
insert into address values('Add3','Nepal','Pokhara', 890776);
insert into address values('Add4','Nepal','Hetauda', 675383);
insert into address values('Add5','Nepal','Birgunj', 324543);
insert into address values('Add6','Nepal','Biratnagar', 213244);
insert into address values('Add7','India','Bombay', 974904);
insert into address values('Add8','India','Sikkim', 793445);


insert into person values('P1','Ishan','Chemjong', 'limbuisan@gmail.com');
insert into person values('P2','Ram','Limbu', 'ramlimbu@gmail.com');
insert into person values('P3','Hari','Sharma', 'harisharma@gmail.com');
insert into person values('P4','Lekhnath','Katuwal', 'Lekhanthkatuwal@gmail.com');
insert into person values('P5','Stuti','Shrestha', 'stutishrestha@gmail.com');
insert into person values('P6','John','Lenon', 'lenonjohn@gmail.com');
insert into person values('P7','Mark','Jobs', 'markhunter@gmail.com');
insert into person values('P8','Rony','Rai', 'ronymercury@gmail.com');
insert into person values('P9','Shruti','Chaudhary', 'shrutichad@gmail.com');
insert into person values('P10','Anish','Shrestha', 'anishshrestha@gmail.com');
insert into person values('P11','Ashish','Ghale', 'ghaleashish@gmail.com');
insert into person values('P12','Sanjeev','KC', 'sanjeev@gmail.com');
insert into person values('P13','Ashim','Nepal', 'ashimgreatest@gmail.com');
insert into person values('P14','Anmol','Amatya', 'hondaanmol@gmail.com');
insert into person values('P15','Ixsa','Limbu', 'ixsalimbu@gmail.com');


commit;


insert into person_address_info values('P1','Add1');
insert into person_address_info values('P2','Add2');
insert into person_address_info values('P3','Add2');
insert into person_address_info values('P4','Add3');
insert into person_address_info values('P5','Add4');
insert into person_address_info values('P6','Add7');
insert into person_address_info values('P7','Add8');
insert into person_address_info values('P8','Add1');
insert into person_address_info values('P9','Add5');
insert into person_address_info values('P10','Add6');
insert into person_address_info values('P11','Add3');
insert into person_address_info values('P12','Add4');
insert into person_address_info values('P13','Add3');
insert into person_address_info values('P14','Add2');
insert into person_address_info values('P15','Add1');

commit;



insert into student values('P1',2);
insert into student values('P3',1);
insert into student values('P4',3);
insert into student values('P5',3);
insert into student values('P6',2);
insert into student values('P7',1);
insert into student values('P10',1);
insert into student values('P11',1);
insert into student values('P12',1);
insert into student values('P14',1);

commit;

insert into teacher values('Tutor', 30000, 'P2');
insert into teacher values('Lecturer', 60000, 'P8');
insert into teacher values('Module-Head', 120000, 'P9');
insert into teacher values('Lecturer', 60000, 'P13');
insert into teacher values('Tutor', 30000, 'P15');

commit;



insert into departments values('D1','Finance');
insert into departments values('D2','RTE');
insert into departments values('D3','Student Services');
insert into departments values('D4','Human Resources');
insert into departments values('D5','Marketing');

commit;


insert into module values('M1','CC50NI','Application Development',24,30);
insert into module values('M2','CC45NI','Database Management',26,30);
insert into module values('M3','CS60NI','Work Related Learning',12,15);
insert into module values('M4','CC13NI','Final Year Project',38,60);
insert into module values('M5','CS14NI','Information System',12,30);

commit;



insert into teacher_module_info values('P2', 'M2');
insert into teacher_module_info values('P8', 'M2');
insert into teacher_module_info values('P9', 'M3');
insert into teacher_module_info values('P13', 'M5');
insert into teacher_module_info values('P15', 'M1');

commit;




insert into assignment values('Ass1', 'MCQ', 'D2', 'M2');
insert into assignment values('Ass2', 'Coursework', 'D2', 'M1');
insert into assignment values('Ass3', 'Groupwork', 'D2', 'M2');
insert into assignment values('Ass4', 'Unseen Examination', 'D2', 'M1');
insert into assignment values('Ass5', 'Coursework', 'D2', 'M2');
insert into assignment values('Ass6', 'Coursework', 'D2', 'M3');
insert into assignment values('Ass7', 'Unseen Examination', 'D2', 'M4');

commit;



insert into student_attendence_info values('P1', 'M1', TO_DATE('Feb 12 2003', 'Mon DD YYYY'), 'D3');
insert into student_attendence_info values('P3', 'M2', TO_DATE('Feb 12 2003', 'Mon DD YYYY'), 'D3');
insert into student_attendence_info values('P4', 'M3', TO_DATE('Feb 12 2003', 'Mon DD YYYY'), 'D3');
insert into student_attendence_info values('P5', 'M4', TO_DATE('Feb 12 2003', 'Mon DD YYYY'), 'D3');
insert into student_attendence_info values('P6', 'M1', TO_DATE('Feb 12 2003', 'Mon DD YYYY'), 'D3');
insert into student_attendence_info values('P7', 'M2', TO_DATE('Feb 12 2003', 'Mon DD YYYY'), 'D3');
insert into student_attendence_info values('P10', 'M3', TO_DATE('Feb 12 2003', 'Mon DD YYYY'), 'D3');
insert into student_attendence_info values('P11', 'M1', TO_DATE('Feb 12 2003', 'Mon DD YYYY'), 'D3');
insert into student_attendence_info values('P12', 'M2', TO_DATE('Feb 12 2003', 'Mon DD YYYY'), 'D3');
insert into student_attendence_info values('P14', 'M2', TO_DATE('Feb 12 2003', 'Mon DD YYYY'), 'D3');

commit;







insert into student_fee_payment values('Pay1', '100000', 2, TO_DATE('Feb 12 2003', 'Mon DD YYYY'), 'P1','D1');
insert into student_fee_payment values('Pay2', '150000', 1, TO_DATE('Mar 21 2003', 'Mon DD YYYY'), 'P3','D1');
insert into student_fee_payment values('Pay3', '100000', 3, TO_DATE('Jan 22 2003', 'Mon DD YYYY'), 'P4','D1');
insert into student_fee_payment values('Pay4', '114000', 2, TO_DATE('Feb 18 2003', 'Mon DD YYYY'), 'P7','D1');
insert into student_fee_payment values('Pay5', '100000', 1, TO_DATE('Jan 01 2003', 'Mon DD YYYY'), 'P10','D1');
insert into student_fee_payment values('Pay6', '150000', 1, TO_DATE('Apr 12 2003', 'Mon DD YYYY'), 'P11','D1');
insert into student_fee_payment values('Pay7', '200000', 2, TO_DATE('Feb 19 2003', 'Mon DD YYYY'), 'P12','D1');
insert into student_fee_payment values('Pay8', '114000', 3, TO_DATE('Jan 06 2003', 'Mon DD YYYY'), 'P14','D1');

commit;



insert into module_student values('M1', 'P1');
insert into module_student values('M2', 'P3');
insert into module_student values('M3', 'P4');
insert into module_student values('M4', 'P5');
insert into module_student values('M1', 'P6');
insert into module_student values('M2', 'P7');
insert into module_student values('M3', 'P10');
insert into module_student values('M1', 'P11');
insert into module_student values('M2', 'P12');
insert into module_student values('M2', 'P14');

commit;



insert into result_info values('R1', 'Ass2', 'A', 'Pass','P1');
insert into result_info values('R2', 'Ass3', 'C', 'Pass','P3');
insert into result_info values('R3', 'Ass6', 'A', 'Pass','P4');
insert into result_info values('R4', 'Ass7', 'D', 'Fail','P5');
insert into result_info values('R5', 'Ass2', 'B', 'Pass','P6');
insert into result_info values('R6', 'Ass3', 'A', 'Pass','P7');
insert into result_info values('R7', 'Ass6', 'D', 'Fail','P10');
insert into result_info values('R8', 'Ass2', 'A', 'Pass','P11');
insert into result_info values('R9', 'Ass3', 'A', 'Pass','P12');
insert into result_info values('R10', 'Ass3', 'D', 'Fail','P14');

commit;












