package ua.nure.sensormonitoring.dataClasses;

/**
 * Created by Александр on 19.12.2016.
 */
public class Subscription {
    private int userId;
    private int sensorId;

    public int getUserId() {
        return userId;
    }

    public void setUserId(int userId) {
        this.userId = userId;
    }

    public int getSensorId() {
        return sensorId;
    }

    public void setSensorId(int sensorId) {
        this.sensorId = sensorId;
    }
}
