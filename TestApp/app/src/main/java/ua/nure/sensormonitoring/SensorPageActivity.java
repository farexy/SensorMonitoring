package ua.nure.sensormonitoring;

import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.app.NotificationCompat;
import android.widget.TextView;

import ua.nure.sensormonitoring.dataClasses.DB;
import ua.nure.sensormonitoring.dataClasses.Readings;
import ua.nure.sensormonitoring.dataClasses.Sensor;
import ua.test.startup.testapp.R;

public class SensorPageActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        long id = Long.parseLong(getIntent().getStringExtra("id"));
        setContentView(R.layout.activity_sensor_page);

        Sensor sensor= DB.Sensors.get(new Integer((int)id));

        ((TextView) findViewById(R.id.nameTextView)).append(sensor.getName());
        ((TextView) findViewById(R.id.placeTextView)).append(sensor.getPlace());
        ((TextView) findViewById(R.id.dimensionTextView)).append(sensor.getDimension());
        ((TextView) findViewById(R.id.limitTextView)).append(Double.toString(sensor.getLimit()));
        ((TextView) findViewById(R.id.subsctanseTextView)).append(sensor.getSubstance());
        if(id == 1){
            loadReading();
            //createInfoNotification("ibcuwnk");
        }

    }

    public void createInfoNotification(String message) {
        //Context context = getApplication();
        Intent notificationIntent = new Intent(SensorPageActivity.this, GreetingsActivity.class); // по клику на уведомлении откроется HomeActivity
        android.support.v4.app.NotificationCompat.Builder nb = new NotificationCompat.Builder(SensorPageActivity.this)
//NotificationCompat.Builder nb = new NotificationBuilder(context) //для версии Android > 3.0
                .setSmallIcon(R.drawable.favicon) //иконка уведомления
                .setAutoCancel(true) //уведомление закроется по клику на него
                .setTicker(message) //текст, который отобразится вверху статус-бара при создании уведомления
                .setContentText(message) // Основной текст уведомления
                .setContentIntent(PendingIntent.getActivity(this, 0, notificationIntent, PendingIntent.FLAG_UPDATE_CURRENT))
                .setWhen(System.currentTimeMillis()) //отображаемое время уведомления
                .setContentTitle("Sensor Monitoring") //заголовок уведомления
                .setDefaults(Notification.DEFAULT_ALL); // звук, вибро и диодный индикатор выставляются по умолчанию

        Notification notification = nb.mNotification; //генерируем уведомление
        NotificationManager manager = (NotificationManager) SensorPageActivity.this.getSystemService(Context.NOTIFICATION_SERVICE);
        manager.notify(1, notification);
    }

    private void loadReading(){

        ((TextView)findViewById(R.id.currentReading)).setText(Double.toString(Readings.generateReading()));
        //loadReading();
    }
}
