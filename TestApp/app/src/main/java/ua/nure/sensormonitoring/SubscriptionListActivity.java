package ua.nure.sensormonitoring;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.VolleyLog;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.ProtocolException;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import ua.nure.sensormonitoring.dataClasses.DB;
import ua.nure.sensormonitoring.dataClasses.Sensor;
import ua.test.startup.testapp.R;

public class SubscriptionListActivity extends AppCompatActivity {

    private static String JSON_URL = "http://192.168.1.7:24688/api/subscription/get?userId=";
    private ListView listView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_subscription_list);


        listView = (ListView)findViewById(R.id.listView);
        try {
            Thread.sleep(2000);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        String[] id = {"1","2"};
        String[] name = {"Oxyg", "Nico"};
        String[] place = {"kharkiv, nure", "frdher"};

        List<String> ids = new ArrayList<>();
        List<String> names = new ArrayList<>();
        List<String> places = new ArrayList<>();

        for(Map.Entry<Integer, Sensor> entry : DB.Sensors.entrySet()){
            ids.add(Integer.toString(entry.getValue().getId()));
            names.add(entry.getValue().getName());
            places.add(entry.getValue().getPlace());
        }

        SubscriptionListView adapter = new SubscriptionListView(this, ids, names, places);
        listView.setAdapter(adapter);
        listView.setOnItemClickListener(listClick);

    }

    AdapterView.OnItemClickListener listClick = new AdapterView.OnItemClickListener() {
        @Override
        public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
            Intent sensInfo = new Intent(SubscriptionListActivity.this, SensorPageActivity.class);
            sensInfo.putExtra("id", Long.toString(id));
            startActivity(sensInfo);
        }
    };


    private void sendRequest() throws IOException {
        HttpURLConnection urlConnection = null;

        URL url = new URL(JSON_URL + "1");

        urlConnection = (HttpURLConnection) url.openConnection();

        urlConnection.setRequestMethod("GET");
        urlConnection.setReadTimeout(10000 /* milliseconds */);
        urlConnection.setConnectTimeout(15000 /* milliseconds */);

        urlConnection.setDoOutput(true);

        urlConnection.connect();

        BufferedReader br=new BufferedReader(new InputStreamReader(url.openStream()));

        char[] buffer = new char[1024];

        String jsonString = new String();

        StringBuilder sb = new StringBuilder();
        String line;
        while ((line = br.readLine()) != null) {
            sb.append(line+"\n");
        }
        br.close();

        jsonString = sb.toString();

        System.out.println("JSON: " + jsonString);
    }

}
