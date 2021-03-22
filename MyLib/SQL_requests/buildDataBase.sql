SELECT * FROM table_stockparts;
SELECT * FROM table_customer;
SELECT modelbike_name, modelbike_size, modelbike_stand, modelbike_brakekit, modelbike_gearkit, modelbike_frame_S01, modelbike_reinforcedframe_S01 FROM table_modelbike;
SELECT * FROM table_bike;

DESCRIBE `table_customer`;
DESCRIBE `table_modelbike`;
DESCRIBE `table_bike`;
DESCRIBE `table_stockparts`;


DROP TABLE `table_customer`;
CREATE TABLE IF NOT EXISTS `table_customer`
(
    `id_customer` INT AUTO_INCREMENT NOT NULL,
    `customer_firstname` VARCHAR(64) NOT NULL,
    `customer_lastname` VARCHAR(64) NOT NULL,
    `customer_email` VARCHAR(64) NOT NULL,
    `customer_phonenumber` VARCHAR(64) NOT NULL,
    `customer_country` VARCHAR(64) NOT NULL,
    `customer_zipcode` VARCHAR(64) NOT NULL,
    `customer_city` VARCHAR(64) NOT NULL,
    `customer_street` VARCHAR(64) NOT NULL,
    `customer_housenumber` VARCHAR(64) NOT NULL,

    PRIMARY KEY(`id_customer`)
);

DROP TABLE `table_modelbike`;
CREATE TABLE IF NOT EXISTS `table_modelbike`
(
    `id_modelbike` INT AUTO_INCREMENT NOT NULL,
    `modelbike_name` VARCHAR(64) NOT NULL,
    `modelbike_size` INT NOT NULL,
    `modelbike_stand` INT,
    `modelbike_brakekit` INT,
    `modelbike_gearkit` INT,
    `modelbike_frame_S01` INT,
    `modelbike_frame_S02` INT,
    `modelbike_reinforcedframe_S01` INT,
    `modelbike_reinforcedframe_S02` INT,
    `modelbike_cranksetkit` INT,
    `modelbike_sprocketcassette` INT,
    `modelbike_reflector` INT,
    `modelbike_chain` INT,
    `modelbike_mudguard_S01` INT,
    `modelbike_mudguard_S02` INT,
    `modelbike_widemudguard_S01` INT,
    `modelbike_widemudguard_S02` INT,
    `modelbike_innertube` INT,
    `modelbike_derailleur` INT,
    `modelbike_brakedisk` INT,
    `modelbike_lighting` INT,
    `modelbike_fork_S01` INT,
    `modelbike_fork_S02` INT,
    `modelbike_handlebar` INT,
    `modelbike_chainring` INT,
    `modelbike_tire_S01` INT,
    `modelbike_tire_S02` INT,
    `modelbike_widetire_S01` INT,
    `modelbike_widetire_S02` INT,
    `modelbike_luggagerack` INT,
    `modelbike_wheel_S01` INT,
    `modelbike_wheel_S02` INT,
    `modelbike_saddle` INT,

    PRIMARY KEY(`id_modelbike`)
);


DROP TABLE `table_bike`;
CREATE TABLE IF NOT EXISTS `table_bike`
(
    `id_bike` INT AUTO_INCREMENT NOT NULL,
    `bike_model` VARCHAR(64) NOT NULL,
    `bike_color` VARCHAR(64) NOT NULL,
    `bike_size` VARCHAR (64) NOT NULL,
    `bike_quantity` INT NOT NULL,
    `bike_idcustomer` INT NOT NULL,
    `bike_creationdate` DATE NOT NULL,
    `bike_assemblingdate` DATE,
    `bike_employee` VARCHAR(64),

    PRIMARY KEY(`id_bike`),
    FOREIGN KEY (`bike_idcustomer`) REFERENCES  `table_customer`(`id_customer`)
);


DROP TABLE `table_stockparts`;
CREATE TABLE IF NOT EXISTS `table_stockparts`
(
    `id_stockparts` INT AUTO_INCREMENT NOT NULL,
    `stockparts_name` VARCHAR(64) NOT NULL,
    `stockparts_sizemodel` INT  NOT NULL,
    `stockparts_whitestock` INT,
    `stockparts_blackstock` INT,
    `stockparts_purplestock` INT,
    `stockparts_nocolorstock` INT,
    `stockparts_unitprice` INT NOT NULL,

    PRIMARY KEY (`id_stockparts`)
);


DROP TABLE `table_employee`;
CREATE TABLE IF NOT EXISTS `table_employee`
(
    `id_employee` INT AUTO_INCREMENT NOT NULL,
    `employee_firstname` VARCHAR(64) NOT NULL,
    `employee_lastname` VARCHAR(64) NOT NULL,
    `employee_status` VARCHAR(64) NOT NULL,

    PRIMARY KEY (`id_employee`)
);
