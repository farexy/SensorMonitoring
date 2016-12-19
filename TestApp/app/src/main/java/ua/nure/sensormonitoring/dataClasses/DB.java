package ua.nure.sensormonitoring.dataClasses;

import java.util.ArrayList;
import java.util.HashMap;

/**
 * Created by Александр on 19.12.2016.
 */
public class DB {
    public static HashMap<Integer, Sensor> Sensors;

    public static HashMap<String, User> Users;

    public static ArrayList<Subscription> Subscriptions;


    public static void init(){

        Subscriptions = new ArrayList<>();
        Users = new HashMap<>();
        Sensors = new HashMap<>();
        Sensor sens = new Sensor();
        sens.setId(1);
        sens.setName("Oxygen level in Gym, NURE, Kh");
        sens.setPlace("Kharkiv, NURE, Gym");
        sens.setLimit(0.5);
        sens.setDimension("mol");
        sens.setSubstance("Oxygen");
        Sensors.put(sens.getId(), sens);
        sens = new Sensor();
        sens.setId(9);
        sens.setName("Nicotine level in restaurant ");
        sens.setPlace("Ukraine, Kharkiv, Nauki ave. 12/14");
        sens.setLimit(0.5);
        sens.setDimension("gr");
        sens.setSubstance("nicotine");
        Sensors.put(sens.getId(), sens);

        User us = new User();
        us.setId(1);
        us.setEmail("somoff@mail.com");
        us.setFullname("Andrey Somof");
        us.setPassword("sigms");
        Users.put(us.getEmail(), us);
        us = new User();
        us.setId(18);
        us.setEmail("valerchik@mama.ru");
        us.setFullname("Valera");
        us.setPassword("valerchik");
        Users.put(us.getEmail(), us);

    }

}
