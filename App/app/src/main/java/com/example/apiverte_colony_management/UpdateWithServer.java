package com.example.apiverte_colony_management;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.TextView;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;

import com.example.apiverte_colony_management.DTOs.GeneralDTO;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.lang.reflect.Type;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.time.Instant;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.UUID;
import java.util.concurrent.TimeUnit;

public class UpdateWithServer extends AppCompatActivity {

    private EditText server_url_textfield;
    private Button updateButton;
    private ProgressBar progressBar;
    private TextView progressText;
    private String server_url;
    private SharedPreferences sharedPref;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_update_server);

        sharedPref = getApplicationContext().getSharedPreferences("server_url",Context.MODE_PRIVATE);
        server_url = sharedPref.getString("server_url","https://server-io6.conveyor.cloud/");

        server_url_textfield = findViewById(R.id.serverAddressTextField);
        server_url_textfield.setText(server_url);

        progressText = findViewById(R.id.progressText);

        updateButton = findViewById(R.id.updateButton);
        progressBar = findViewById(R.id.progressBar);
        progressBar.setVisibility(View.INVISIBLE);

        updateButton.setOnClickListener( new View.OnClickListener(){
            public void onClick(View v) {
                ServerUpdate request = new ServerUpdate();
                request.execute();
            }
        });

    }

    class ServerUpdate extends AsyncTask< String, Integer, String> {

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            server_url = server_url_textfield.getText().toString();
            progressBar.setVisibility(View.VISIBLE);

        }

        private final int SYNC_USERS = 0;
        private final int SYNC_AREAS = 1;
        private final int SYNC_HOSTS = 2;
        private final int SYNC_COLONIES = 3;
        private final int SYNC_TYPICAL = 4;
        private final int SYNC_SPECIAL = 5;
        private final int SYNC_DONE = 6;
        private final int SYNC_ERROR = 7;

        @Override
        protected String doInBackground(String... strings) {
            try{
                publishProgress(SYNC_USERS);
                SyncUsers();
                publishProgress(SYNC_AREAS);
                SyncAreas();
                publishProgress(SYNC_HOSTS);
                SyncHost();
                publishProgress(SYNC_COLONIES);
                SyncColony();
                publishProgress(SYNC_TYPICAL);
                SyncTypicalInspection();
                publishProgress(SYNC_SPECIAL);
                SyncSpecialInspection();
                publishProgress(SYNC_DONE);
            } catch (Exception ex){
                Log.e("Error", ex.getMessage());
                publishProgress(SYNC_ERROR);
                progressBar.setVisibility(View.INVISIBLE);
                cancel(true);
            }
            return "Done";
        }

        private void SyncUsers() throws IOException {
                List<GeneralDTO> Local_Users = GetUsersFromLocal();
                URL sync_users_url = new URL(server_url + "User/SyncUsers");
                HttpURLConnection sync_users_con = (HttpURLConnection) sync_users_url.openConnection();
                sync_users_con.setRequestMethod("POST");
                sync_users_con.setRequestProperty("Content-Type", "application/json; utf-8");
                sync_users_con.setRequestProperty("Accept", "application/json");
                sync_users_con.setDoOutput(true);
                Gson gson = new Gson();
                String users_json = gson.toJson(Local_Users);
                try(OutputStream os = sync_users_con.getOutputStream()) {
                    byte[] input = users_json.getBytes("utf-8");
                    os.write(input, 0, input.length);

                    try(BufferedReader br = new BufferedReader(
                            new InputStreamReader(sync_users_con.getInputStream(), "utf-8"))) {
                        StringBuilder response = new StringBuilder();
                        String responseLine = null;
                        while ((responseLine = br.readLine()) != null) {
                            response.append(responseLine.trim());
                        }
                        Type generalDTOType = new TypeToken<ArrayList<GeneralDTO>>(){}.getType();
                        Local_Users = gson.fromJson(response.toString(),generalDTOType);
                        SaveUsersToLocal(Local_Users);
                    }
                }


        }

        private List<GeneralDTO> GetUsersFromLocal() {
            //TODO: query all users from database and create a list of GeneralDTO with it
            return null;
        }

        private void SaveUsersToLocal(List<GeneralDTO> users){
            //TODO: Given the modified list of users, update all current db info with it
        }

        private void SyncAreas(){
            try {
                TimeUnit.SECONDS.sleep(2);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }

        private void SyncColony(){
            try {
                TimeUnit.SECONDS.sleep(2);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }

        private void SyncHost(){
            try {
                TimeUnit.SECONDS.sleep(2);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }

        private void SyncTypicalInspection(){
            try {
                TimeUnit.SECONDS.sleep(2);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }

        }

        private void SyncSpecialInspection(){
            try {
                TimeUnit.SECONDS.sleep(2);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }

        @Override
        protected void onPostExecute(String args){
            //if syncing was successful, save the server url
            SharedPreferences.Editor editor = sharedPref.edit();
            editor.putString("server_url",server_url);
            editor.apply();
            progressBar.setVisibility(View.INVISIBLE);
        }

        @Override
        protected void onProgressUpdate(Integer... values) {
            switch (values[0]){
                case SYNC_USERS:
                    progressText.setText(R.string.SyncingUsers);
                    break;
                case SYNC_AREAS:
                    progressText.setText(R.string.SyncingAreas);
                    break;
                case SYNC_HOSTS:
                    progressText.setText(R.string.SyncingHost);
                    break;
                case SYNC_COLONIES:
                    progressText.setText(R.string.SyncingColonies);
                    break;
                case SYNC_TYPICAL:
                    progressText.setText(R.string.SyncingTypical);
                    break;
                case SYNC_SPECIAL:
                    progressText.setText(R.string.SyncingSpecial);
                    break;
                case SYNC_DONE:
                    progressText.setText(R.string.SyncingDone);
                    break;
                case SYNC_ERROR:
                    progressText.setText(R.string.SyncingError);
                    break;
            }
        }
    }
}
