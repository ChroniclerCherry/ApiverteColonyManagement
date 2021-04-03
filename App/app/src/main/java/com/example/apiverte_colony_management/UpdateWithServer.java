package com.example.apiverte_colony_management;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.PersistableBundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.TextView;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.concurrent.TimeUnit;

public class UpdateWithServer extends AppCompatActivity {

    private EditText server_url_textfield;
    private Button updateButton;
    private ProgressBar progressBar;
    private String server_url;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_update_server);

        SharedPreferences sharedPref = getApplicationContext().getSharedPreferences("server_url",Context.MODE_PRIVATE);
        server_url = sharedPref.getString("url","https://server-io6.conveyor.cloud/");

        server_url_textfield = findViewById(R.id.serverAddressTextField);
        server_url_textfield.setText(server_url);

        updateButton = findViewById(R.id.updateButton);
        progressBar = findViewById(R.id.progressBar);

        updateButton.setOnClickListener( new View.OnClickListener(){
            public void onClick(View v) {
                server_url = server_url_textfield.getText().toString();
                ServerUpdate request = new ServerUpdate();
                progressBar.setVisibility(View.VISIBLE);
                request.execute();
            }
        });


    }

    class ServerUpdate extends AsyncTask< String, Integer, String> {

        @Override
        protected String doInBackground(String... strings) {
            try{
                SyncUsers();
                SyncAreas();
                SyncColony();
                SyncHost();
                SyncTypicalInspection();
                SyncSpecialInspection();
            } catch (Exception ex){
                Log.e("Error", ex.getMessage());
                cancel(true);
                finish();
            }
            return "Done";
        }

        private void SyncUsers() throws IOException {
            URL get_users_url = new URL(server_url + "User/GetUsers");
            HttpURLConnection get_users_con = (HttpURLConnection) get_users_url.openConnection();
            InputStream response = get_users_con.getInputStream();
            get_users_con.connect();
            response = get_users_con.getInputStream();

            BufferedReader reader = new BufferedReader(new InputStreamReader(response, "UTF-8"), 8);
            StringBuilder sb = new StringBuilder();


            String line;
            while ((line = reader.readLine()) != null)
            {
                sb.append(line + "\n");
            }

            String result = sb.toString();

            get_users_con.disconnect();

            URL add_users_url = new URL(server_url + "User/GetUsers");
            URL edit_users_url = new URL(server_url + "User/GetUsers");
        }

        private void SyncAreas(){

        }

        private void SyncColony(){

        }

        private void SyncHost(){

        }

        private void SyncTypicalInspection(){

        }

        private void SyncSpecialInspection(){

        }

        @Override
        protected void onPostExecute(String args){
            progressBar.setVisibility(View.INVISIBLE);
        }
    }
}
