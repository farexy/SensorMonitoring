package ua.nure.sensormonitoring.items;

import ua.nure.sensormonitoring.dataClasses.Sensor;

public class SensorDetailsView {

    public SensorDetailsView(){}

    public SensorDetailsView(Sensor sensor){
        this.name = sensor.getName();
        this.itemDescription = sensor.getPlace();
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getItemDescription() {
        return itemDescription;
    }

    public void setItemDescription(String itemDescription) {
        this.itemDescription = itemDescription;
    }

    public String getPrice() {
        return price;
    }

    public void setPrice(String price) {
        this.price = price;
    }

    public int getImageNumber() {
        return imageNumber;
    }

    public void setImageNumber(int imageNumber) {
        this.imageNumber = imageNumber;
    }

    private String name ;

    private String itemDescription;

    private String price;

    private int imageNumber;
}