DELETE FROM table_modelbike;

INSERT INTO table_modelbike(
    modelbike_name,
    modelbike_size,
    modelbike_stand,
    modelbike_brakekit,
    modelbike_gearkit,
    modelbike_frame_S01,
    modelbike_cranksetkit,
    modelbike_sprocketcassette,
    modelbike_reflector,
    modelbike_chain,
    modelbike_mudguard_S01,
    modelbike_innertube,
    modelbike_derailleur,
    modelbike_brakedisk,
    modelbike_lighting,
    modelbike_fork_S01,
    modelbike_handlebar,
    modelbike_chainring,
    modelbike_tire_S01,
    modelbike_luggagerack,
    modelbike_wheel_S01,
    modelbike_saddle
    )
VALUES ("city",1,1,1,1,1,1,1,4,1,1,2,1,2,1,1,1,1,2,1,2,1);
INSERT INTO table_modelbike(
    modelbike_name,
    modelbike_size,
    modelbike_stand,
    modelbike_brakekit,
    modelbike_gearkit,
    modelbike_frame_S02,
    modelbike_cranksetkit,
    modelbike_sprocketcassette,
    modelbike_reflector,
    modelbike_chain,
    modelbike_mudguard_S01,
    modelbike_innertube,
    modelbike_derailleur,
    modelbike_brakedisk,
    modelbike_lighting,
    modelbike_fork_S02,
    modelbike_handlebar,
    modelbike_chainring,
    modelbike_tire_S02,
    modelbike_luggagerack,
    modelbike_wheel_S02,
    modelbike_saddle
    )
VALUES ("city",2,1,1,1,1,1,1,4,1,1,2,1,2,1,1,1,1,2,1,2,1);

INSERT INTO table_modelbike(
    modelbike_name,
    modelbike_size,
    modelbike_stand,
    modelbike_brakekit,
    modelbike_gearkit,
    modelbike_frame_S01,
    modelbike_cranksetkit,
    modelbike_sprocketcassette,
    modelbike_reflector,
    modelbike_chain,
    modelbike_widemudguard_S01,
    modelbike_innertube,
    modelbike_derailleur,
    modelbike_brakedisk,
    modelbike_lighting,
    modelbike_fork_S01,
    modelbike_handlebar,
    modelbike_chainring,
    modelbike_widetire_S01,
    modelbike_luggagerack,
    modelbike_wheel_S01,
    modelbike_saddle
    )
VALUES ("explorer",1,1,1,1,1,1,1,4,1,1,2,1,2,1,1,1,1,2,1,2,1);
INSERT INTO table_modelbike(
    modelbike_name,
    modelbike_size,
    modelbike_stand,
    modelbike_brakekit,
    modelbike_gearkit,
    modelbike_frame_S02,
    modelbike_cranksetkit,
    modelbike_sprocketcassette,
    modelbike_reflector,
    modelbike_chain,
    modelbike_widemudguard_S02,
    modelbike_innertube,
    modelbike_derailleur,
    modelbike_brakedisk,
    modelbike_lighting,
    modelbike_fork_S02,
    modelbike_handlebar,
    modelbike_chainring,
    modelbike_widetire_S02,
    modelbike_luggagerack,
    modelbike_wheel_S02,
    modelbike_saddle
    )
VALUES ("explorer",2,1,1,1,1,1,1,4,1,1,2,1,2,1,1,1,1,2,1,2,1);

INSERT INTO table_modelbike(
    modelbike_name,
    modelbike_size,
    modelbike_stand,
    modelbike_brakekit,
    modelbike_gearkit,
    modelbike_reinforcedframe_S01,
    modelbike_cranksetkit,
    modelbike_sprocketcassette,
    modelbike_reflector,
    modelbike_chain,
    modelbike_innertube,
    modelbike_derailleur,
    modelbike_brakedisk,
    modelbike_fork_S01,
    modelbike_handlebar,
    modelbike_chainring,
    modelbike_widetire_S01,
    modelbike_wheel_S01,
    modelbike_saddle
    )
VALUES ("adventure",1,1,1,1,1,1,1,4,1,2,1,2,1,1,1,2,2,1);
INSERT INTO table_modelbike(
    modelbike_name,
    modelbike_size,
    modelbike_stand,
    modelbike_brakekit,
    modelbike_gearkit,
    modelbike_reinforcedframe_S02,
    modelbike_cranksetkit,
    modelbike_sprocketcassette,
    modelbike_reflector,
    modelbike_chain,
    modelbike_innertube,
    modelbike_derailleur,
    modelbike_brakedisk,
    modelbike_fork_S02,
    modelbike_handlebar,
    modelbike_chainring,
    modelbike_widetire_S02,
    modelbike_wheel_S02,
    modelbike_saddle
    )
VALUES ("adventure",2,1,1,1,1,1,1,4,1,2,1,2,1,1,1,2,2,1);
SELECT modelbike_name, modelbike_size FROM table_modelbike;