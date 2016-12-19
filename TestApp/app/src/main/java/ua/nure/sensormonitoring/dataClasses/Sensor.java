package ua.nure.sensormonitoring.dataClasses;

/**
 * Created by Александр on 16.12.2016.
 */
public class Sensor {
    private int Id ;
    private String name;
    private String place ;
    private String substance;
    private double limit;
    private String dimension;
    private String password ;

    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPlace() {
        return place;
    }

    public void setPlace(String place) {
        this.place = place;
    }

    public String getSubstance() {
        return substance;
    }

    public void setSubstance(String substance) {
        this.substance = substance;
    }

    public double getLimit() {
        return limit;
    }

    public void setLimit(double limit) {
        this.limit = limit;
    }

    public String getDimension() {
        return dimension;
    }

    public void setDimension(String dimension) {
        this.dimension = dimension;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
