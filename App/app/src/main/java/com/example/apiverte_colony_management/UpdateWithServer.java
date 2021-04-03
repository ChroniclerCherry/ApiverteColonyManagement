package com.example.apiverte_colony_management;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;

import androidx.appcompat.app.AppCompatActivity;

import com.example.apiverte_colony_management.DTOs.GeneralDTO;
import com.google.gson.Gson;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

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
            List<GeneralDTO> Server_Users = GetUsersFromServer();
            List<GeneralDTO> Local_Users = GetUsersFromLocal();
            //TODO: compare users from local db and server and only keep the newest versions of each

            SaveUsersToLocal();
            SaveUsersToServer();


        }

        private List<GeneralDTO> GetUsersFromLocal() {
            //TODO: get users from local database
            return null;
        }

        private void SaveUsersToLocal() {
            //TODO; save updated users to server
        }

        private List<GeneralDTO> GetUsersFromServer() throws IOException {
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
            List<GeneralDTO> Users = new ArrayList<>();
            try {
                JSONArray users_json = new JSONArray (result);
                for (int i = 0; i < users_json.length(); i++){
                    JSONObject user = users_json.getJSONObject(i);
                    GeneralDTO userDTO = new Gson().fromJson(user.toString(),GeneralDTO.class);
                    Users.add(userDTO);
                }

            } catch (JSONException ex) {
                Log.e("Error", ex.getMessage());
            }

            get_users_con.disconnect();
            return Users;
        }

        private void SaveUsersToServer() throws IOException{
            //TODO: save updated users to local db
            URL get_users_url = new URL(server_url + "User/SaveUsers");
        }

        private void SyncAreas(){
            //TODO: get areas from server
            //TODO: get areas from local database
            //TODO: compare areas from local db and server and only keep the newest versions of each
            //TODO: save updated areas to local db
            //TODO; save updated areas to server
        }

        private void SyncColony(){
            //TODO: get colonies from server
            //TODO: get colonies from local database
            //TODO: compare colonies from local db and server and only keep the newest versions of each
            //TODO: save updated colonies to local db
            //TODO; save updated colonies to server
        }

        private void SyncHost(){
            //TODO: get colonies from server
            //TODO: get colonies from local database
            //TODO: compare colonies from local db and server and only keep the newest versions of each
            //TODO: save updated colonies to local db
            //TODO; save updated colonies to server
        }

        private void SyncTypicalInspection(){
            //TODO: get colonies from server
            //TODO: get colonies from local database
            //TODO: compare colonies from local db and server and only keep the newest versions of each
            //TODO: save updated colonies to local db
            //TODO; save updated colonies to server

        }

        private void SyncSpecialInspection(){
            //TODO: get colonies from server
            //TODO: get colonies from local database
            //TODO: compare colonies from local db and server and only keep the newest versions of each
            //TODO: save updated colonies to local db
            //TODO; save updated colonies to server
        }

        @Override
        protected void onPostExecute(String args){
            progressBar.setVisibility(View.INVISIBLE);
        }
    }
}
