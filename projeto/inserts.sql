/*
insert into Cliente values (1 , 'Baxac' , 966272585, 'Rua das flores n21, aveiro');
insert into Cliente values (2 , 'Baxxon' , 966272888, 'Rua das caves n92, aveiro');
insert into Cliente values (3 , 'zakarias' , 966272999, 'Rua das tulipas n90, aveiro');
insert into Cliente values (4 , 'Maneul' , 966272456, 'Rua dr candido de silva n77, aveiro');
insert into Cliente values (5 , 'Shaffron' , 966272132, 'Rua 25 de abril n33, aveiro');
insert into Cliente values (6 , 'Tomat' , 966272852, 'Rua de fatima n55, aveiro');
insert into Cliente values (7 , 'Prtty' , 966272145, 'Rua dr carlos II n32, aveiro');
insert into Cliente values (8 , 'Shl' , 966272753, 'Rua D Infante n24, aveiro');
insert into Cliente values (9 , 'Shain' , 966272167, 'Rua das rosalias n84, aveiro');
insert into Cliente values (10 , 'BaseDado' , 966272942, 'Rua das rosas n55, aveiro');


insert into CategFornec values (1, 'Pele');
insert into CategFornec values (2, 'Palmilhas');
insert into CategFornec values (3, 'Solas');
insert into CategFornec values (4, 'Aplicacoes');

insert into	envio values ('2021-12-24');
insert into	envio values ('2021-12-25');
insert into	envio values ('2021-12-26');
insert into	envio values ('2021-12-27');

insert into Encomenda values (15 , 800 , 0 , 5, '2021-12-24');
insert into Encomenda values (14 , 400 , 0 , 9, '2021-12-24');
insert into Encomenda values (13 , 200 , 1 , 6, '2021-12-24');
insert into Encomenda values (12 , 1000 , 0 , 5, '2021-12-27');
insert into Encomenda values (11 , 100 , 0 , 10, '2021-12-25');
insert into Encomenda values (10 , 850 , 0 , 8, '2021-12-25');
insert into Encomenda values (9 , 800 , 0 , 5, '2021-12-26');
insert into Encomenda values (8 , 2000 , 0 , 1, '2021-12-25');
insert into Encomenda values (7 , 1000 , 0 , 2, '2021-12-24');
insert into Encomenda values (6 , 200 , 0 , 1, '2021-12-27');
insert into	Encomenda values (5 , 150, 1, 8,'2021-12-24');
insert into Encomenda values (4 , 985 , 0 , 5, '2021-12-27');
insert into Encomenda values (3 , 985 , 0 , 7, '2021-12-25');
insert into Encomenda values (2 , 50 , 1 , 4, '2021-12-24');
insert into Encomenda values (1 , 985 , 0 , 3, '2021-12-27');


insert into Materiais values (1001, 50);
insert into Materiais values (1002, 50);
insert into Materiais values (1003, 50);
insert into Materiais values (1010, 50);
insert into Materiais values (1011, 50);
insert into Materiais values (1012, 50);
insert into Materiais values (1020, 50);
insert into Materiais values (1021, 50);
insert into Materiais values (1022, 50);
insert into Materiais values (1030, 50);
insert into Materiais values (1031, 50);
insert into Materiais values (1032, 50);

insert into Pele values (1001, 'verde');
insert into Pele values (1002, 'vermelho');
insert into Pele values (1003, 'preto');

insert into Solas values (1010, 39);
insert into Solas values (1011, 38);
insert into Solas values (1012, 40);

insert into Aplicacoes values (1020, 'cordoes');
insert into Aplicacoes values (1021, 'fechos');
insert into Aplicacoes values (1022, 'fivela');

insert into Palmilhas values (1030, '35');
insert into Palmilhas values (1031, '38');
insert into Palmilhas values (1032, '39');


insert into fornecedor values ('Manuel antonio', 925789658, 1001, 1);
insert into fornecedor values ('Joaquim Ze', 925789658, 1002, 1);
insert into fornecedor values ('Antoine', 925789658, 1003, 1);
insert into fornecedor values ('Carlos Manuel', 935789658, 1010, 3);
insert into fornecedor values ('Carlos Silva', 935789658, 1011, 3);
insert into fornecedor values ('Carlitos', 935789658, 1012, 3);
insert into fornecedor values ('Jean Pierre', 912356478, 1020, 4);
insert into fornecedor values ('Pierre Cardin', 912356478, 1021, 4);
insert into fornecedor values ('Jean Luppin', 912356478, 1022, 4);
insert into fornecedor values ('Pent', 912356888, 1030, 2);
insert into fornecedor values ('Penttozi', 912356888, 1030, 2);
insert into fornecedor values ('Ragazzi', 912356888, 1030, 2);

insert into TipoPag values (1 , 'pronto');
insert into TipoPag values (2 , '30 dias');
insert into TipoPag values (3 , '60 dias');

insert into TipoProd values (1, 'botim');
insert into TipoProd values (2, 'bota');
insert into TipoProd values (3, 'sapatilha');
insert into TipoProd values (4, 'sandalia');
insert into TipoProd values (5, 'mocassim');

insert into TipoSeccao values (1 ,'corte');
insert into TipoSeccao values (2 ,'costura');
insert into TipoSeccao values (3 ,'montagem');
insert into TipoSeccao values (4 ,'acabamento');

insert into Producao values (1500, '2021-11-15','');
insert into Producao values (1400, '2021-11-1','');
insert into Producao values (1300, '2021-11-13', '2021-12-1');
insert into Producao values (1200, '2021-11-9','');
insert into Producao values (1100, '2021-11-4','');
insert into Producao values (1000, '2021-11-5','');
insert into Producao values (0900, '2021-11-9','');
insert into Producao values (0800, '2021-11-20','');
insert into Producao values (0700, '2021-11-21','');
insert into Producao values (0600, '2021-11-3','');
insert into Producao values (0500, '2021-11-2', '2021-12-5');
insert into Producao values (0400, '2021-11-2','');
insert into Producao values (0300, '2021-11-9','');
insert into Producao values (0200, '2021-11-6', '2021-12-3');
insert into Producao values (0100, '2021-11-11','');

insert into Produto values (255, 'bota fancy', 2, 1500, 50);
insert into Produto values (256, 'bota fancy', 2, 1400, 50);
insert into Produto values (257, 'bota fancy', 2, 1300, 50);
insert into Produto values (258, 'bota fancy', 2, 1200, 50);
insert into Produto values (155, 'botim bonito', 1, 1100, 35);
insert into Produto values (156, 'botim bonito', 1, 1000, 35);
insert into Produto values (157, 'botim bonito', 1, 0900, 35);
insert into Produto values (158, 'botim bonito', 1, 0800, 35);
insert into Produto values (355, 'lml', 3, 0700, 40);
insert into Produto values (356, 'lml', 3, 0600, 40);
insert into Produto values (357, 'lml', 3, 0500, 40);
insert into Produto values (358, 'lml', 3, 0400, 40);
insert into Produto values (455, 'sandal', 4, 0300, 25);
insert into Produto values (456, 'sandal', 4, 0200, 25);
insert into Produto values (457, 'sandal', 4, 0100, 25);


insert into Seccao values (1300, '2021-11-13', '2021-11-15', '', 1);
insert into Seccao values (1300, '2021-11-15', '2021-11-16', '', 2);
insert into Seccao values (1300, '2021-11-16', '2021-11-25', '', 3);
insert into Seccao values (1300, '2021-11-27', '2021-12-1', '', 4);
insert into Seccao values (0500, '2021-11-13', '2021-11-15', '', 1);
insert into Seccao values (0500, '2021-11-15', '2021-11-16', '', 2);
insert into Seccao values (0500, '2021-11-16', '2021-11-25', '', 3);
insert into Seccao values (0500, '2021-11-27', '2021-12-5', '', 4);
insert into Seccao values (0200, '2021-11-13', '2021-11-15', '', 1);
insert into Seccao values (0200, '2021-11-15', '2021-11-16', '', 2);
insert into Seccao values (0200, '2021-11-16', '2021-11-25', '', 3);
insert into Seccao values (0200, '2021-11-27', '2021-12-3', '', 4);
insert into Seccao values (0100, '2021-11-16', '2021-11-25', '', 1);
insert into Seccao values (0100, '2021-11-27', '2021-12-3', '', 2);
insert into Seccao values (0800, '2021-11-16', '2021-11-25', '', 1);
insert into Seccao values (0600, '2021-11-27', '2021-12-3', '', 1);


insert into Pertence values (255,15);
insert into Pertence values (255,14);
insert into Pertence values (255,13);
insert into Pertence values (455,12);
insert into Pertence values (256,11);
insert into Pertence values (156,10);
insert into Pertence values (356,9);
insert into Pertence values (456,8);
insert into Pertence values (157,7);
insert into Pertence values (257,6);
insert into Pertence values (357,5);
insert into Pertence values (455,4);
insert into Pertence values (158,3);
insert into Pertence values (258,2);
insert into Pertence values (358,1);

insert into Requer values (1500,15);
insert into Requer values (1400,14);
insert into Requer values (1300,13);
insert into Requer values (1200,12);
insert into Requer values (1100,11);
insert into Requer values (1000,10);
insert into Requer values (0900,9);
insert into Requer values (0800,8);
insert into Requer values (0700,7);
insert into Requer values (0600,6);
insert into Requer values (0500,5);
insert into Requer values (0400,4);
insert into Requer values (0300,3);
insert into Requer values (0200,2);
insert into Requer values (0100,1);

insert into Necessita values (15,1);
insert into Necessita values (14,2);
insert into Necessita values (13,3);
insert into Necessita values (12,1);
insert into Necessita values (11,1);
insert into Necessita values (10,2);
insert into Necessita values (9,2);
insert into Necessita values (8,2);
insert into Necessita values (7,1);
insert into Necessita values (6,3);
insert into Necessita values (5,1);
insert into Necessita values (4,2);
insert into Necessita values (3,2);
insert into Necessita values (2,2);
insert into Necessita values (1,3);

insert into Precisa values (355, 1001, 2);
insert into Precisa values (355, 1010, 1);
insert into Precisa values (355, 1020, 1);
insert into Precisa values (455, 1002, 1);
insert into Precisa values (455, 1010, 1);
insert into Precisa values (455, 1022, 1);
insert into Precisa values (255, 1003, 3);
insert into Precisa values (255, 1010, 1);
insert into Precisa values (255, 1022, 2);
insert into Precisa values (155, 1001, 2);
insert into Precisa values (155, 1010, 1);
insert into Precisa values (155, 1022, 2);

*/





