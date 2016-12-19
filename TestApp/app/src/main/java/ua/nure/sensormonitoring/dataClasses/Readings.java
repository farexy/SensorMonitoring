package ua.nure.sensormonitoring.dataClasses;

import android.widget.RadioButton;

import java.util.Random;

/**
 * Created by Александр on 19.12.2016.
 */
public class Readings {

    private double reading = 0;

    public double getReading(){
        return reading;
    }

    public static double generateReading(){
        Random random = new Random();
        return round(random.nextDouble(), 2);
    }

    public static double round(double value, int places) {
        if (places < 0) throw new IllegalArgumentException();

        long factor = (long) Math.pow(10, places);
        value = value * factor;
        long tmp = Math.round(value);
        return (double) tmp / factor;
    }
}
