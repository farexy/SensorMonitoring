package ua.nure.sensormonitoring;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.android.volley.AuthFailureError;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.VolleyLog;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONException;
import org.json.JSONObject;

import  java.io.UnsupportedEncodingException;
import java.util.HashMap;
import java.util.Map;

import ua.nure.sensormonitoring.dataClasses.DB;
import ua.nure.sensormonitoring.dataClasses.User;
import ua.nure.sensormonitoring.items.Session;
import ua.test.startup.testapp.R;

public class RegisterActivity extends AppCompatActivity {

    final String URL = "http://192.168.1.7:24688/api/user/register/";

    View.OnClickListener register = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            JSONObject jsonBodyObj = new JSONObject();
            try{
                jsonBodyObj.put("Email", ((TextView)findViewById(R.id.emailTextField)).getText().toString());
                jsonBodyObj.put("FullName", ((TextView)findViewById(R.id.fullNameTextField)).getText().toString());
                jsonBodyObj.put("Password", ((TextView)findViewById(R.id.passwordTextField)).getText().toString());
            }catch (JSONException e){
                e.printStackTrace();
            }
            final String requestBody = jsonBodyObj.toString();

            JsonObjectRequest req = new JsonObjectRequest(Request.Method.POST, URL, null,
                    new Response.Listener<JSONObject>() {
                        @Override
                        public void onResponse(JSONObject response) {
                            try {
                                showError(response.toString(4));
                            } catch (JSONException e) {
                                e.printStackTrace();
                            }
                        }
                    }, new Response.ErrorListener() {
                @Override
                public void onErrorResponse(VolleyError error) {
                    VolleyLog.e("Error: %s", error.getMessage());
                }
            }){
                @Override
                public Map<String, String> getHeaders() throws AuthFailureError {
                    HashMap<String, String> headers = new HashMap<String, String>();
                    return headers;
                }

                @Override
                public byte[] getBody() {
                    try {
                        return requestBody == null ? null : requestBody.getBytes("utf-8");
                    } catch (UnsupportedEncodingException uee) {
                        VolleyLog.wtf("Unsupported Encoding while trying to get the bytes of %s using %s",
                                requestBody, "utf-8");
                        return null;
                    }
                }
            };
            RequestQueue queue = Volley.newRequestQueue(RegisterActivity.this);
            queue.add(req);
        }
    };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);
        Button registerButton = (Button)findViewById(R.id.register_button);
        registerButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(validate()) {
                    User us = new User();
                    us.setId(20);
                    us.setFullname(((TextView) findViewById(R.id.fullNameTextField)).getText().toString());
                    us.setEmail(((TextView) findViewById(R.id.emailTextField)).getText().toString());
                    us.setPassword(((TextView) findViewById(R.id.passwordTextField)).getText().toString());
                    DB.Users.put(us.getEmail(), us);
                    Session.setUser(us);
                    Intent intent = new Intent(RegisterActivity.this, SensorListActivity.class);
                    startActivity(intent);
                }
            }
        });
    }

    private boolean validate(){
        String email = ((TextView) findViewById(R.id.emailTextField)).getText().toString();
        String name = ((TextView) findViewById(R.id.fullNameTextField)).getText().toString();
        String password = ((TextView) findViewById(R.id.passwordTextField)).getText().toString();
        String confirm = ((TextView) findViewById(R.id.confirmPasswordTextField)).getText().toString();
        boolean err = true;

        String ePattern = "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$";
        java.util.regex.Pattern p = java.util.regex.Pattern.compile(ePattern);
        java.util.regex.Matcher m = p.matcher(email);
        if(!m.matches()){
            showError("Email isn't correct");
            return false;
        }
        if(name.length() < 3) {
            showError("Name must have not less than 3 letters");
            return false;
        }
        if(password.length() < 5) {
            showError("Password must have not less than 5 letters");
            return false;
        }

        return err;
    }

    private void showError(String Message){
        AlertDialog.Builder builder = new AlertDialog.Builder(RegisterActivity.this);
        builder.setTitle("Error")
                .setMessage(Message)
                .setIcon(android.R.drawable.ic_dialog_alert)
                .setCancelable(false)
                .setNegativeButton("ОК",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                dialog.cancel();
                            }
                        });
        AlertDialog alert = builder.create();
        alert.show();
    }


}
