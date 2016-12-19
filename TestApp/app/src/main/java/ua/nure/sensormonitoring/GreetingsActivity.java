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

import ua.test.startup.testapp.R;

public class GreetingsActivity extends AppCompatActivity {

    private Context context;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_greetings);
        context = getApplication();
        TextView textView = (TextView)findViewById(R.id.textView);
        textView.setText("Hello," + getIntent().getStringExtra("email") + "!");
        createInfoNotification("dcxbjk");
        Context context = getBaseContext();
    }

    public void createInfoNotification(String message){
        Context context = getApplication();
        Intent notificationIntent = new Intent(context, GreetingsActivity.class); // по клику на уведомлении откроется HomeActivity
        android.support.v4.app.NotificationCompat.Builder nb = new NotificationCompat.Builder(context)
//NotificationCompat.Builder nb = new NotificationBuilder(context) //для версии Android > 3.0
                .setSmallIcon(R.drawable.favicon) //иконка уведомления
                .setAutoCancel(true) //уведомление закроется по клику на него
                .setTicker(message) //текст, который отобразится вверху статус-бара при создании уведомления
                .setContentText(message) // Основной текст уведомления
                .setContentIntent(PendingIntent.getActivity(null, 0, notificationIntent, PendingIntent.FLAG_CANCEL_CURRENT))
                .setWhen(System.currentTimeMillis()) //отображаемое время уведомления
                .setContentTitle("Sensor Monitoring") //заголовок уведомления
                .setDefaults(Notification.DEFAULT_ALL); // звук, вибро и диодный индикатор выставляются по умолчанию

        Notification notification = nb.mNotification; //генерируем уведомление
        NotificationManager manager = (NotificationManager) context.getSystemService(Context.NOTIFICATION_SERVICE);
        manager.notify(1, notification);
    }

}
