package ua.nure.sensormonitoring.items;

import ua.nure.sensormonitoring.dataClasses.User;

/**
 * Created by Александр on 19.12.2016.
 */
public class Session {
    private static User user;

    public static User getUser() {
        return user;
    }

    public static void setUser(User us) {
        user = us;
    }
}
