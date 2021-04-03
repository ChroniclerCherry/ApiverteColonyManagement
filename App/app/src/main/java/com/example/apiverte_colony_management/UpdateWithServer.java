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
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.Collections;
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

            for (GeneralDTO ServerUser : Server_Users){
                GeneralDTO local = null;
                //grab local user with same ID as current server user
                for (GeneralDTO l : Local_Users) {
                    if (l.Id == ServerUser.Id) {
                        local = l;
                        break;
                    }
                }
                if (local == null){
                    //if the server user doesn't exist locally, add it
                    Local_Users.add(ServerUser);
                } else {
                    //if the server version of the object is more recent, replace it with the server data
                    if (local.LastModifiedDate < ServerUser.LastModifiedDate){
                        Local_Users.remove(local);
                        Local_Users.add(ServerUser);
                    }
                }
            }

            SaveUsersToLocal(Local_Users);
            SaveUsersToServer(Local_Users);

        }

        private List<GeneralDTO> GetUsersFromLocal() {
            //TODO: get users from local database
            return null;
        }

        private void SaveUsersToLocal(List<GeneralDTO> local_Users) throws IOException {

            for (GeneralDTO user : local_Users){
                URL edit_user_url = new URL(server_url + "User/EditUser");
                HttpURLConnection get_users_con = (HttpURLConnection) edit_user_url.openConnection();
                get_users_con.setRequestMethod("POST");
                get_users_con.setRequestProperty("Content-Type", "application/json; utf-8");
                get_users_con.setRequestProperty("Accept", "application/json");
                get_users_con.setDoOutput(true);
                Gson gson = new Gson();
                String user_json = gson.toJson(user);
                try(OutputStream os = get_users_con.getOutputStream()) {
                    byte[] input = user_json.getBytes("utf-8");
                    os.write(input, 0, input.length);

                    try(BufferedReader br = new BufferedReader(
                            new InputStreamReader(get_users_con.getInputStream(), "utf-8"))) {
                        StringBuilder response = new StringBuilder();
                        String responseLine = null;
                        while ((responseLine = br.readLine()) != null) {
                            response.append(responseLine.trim());
                        }
                        System.out.println(response.toString());
                    }
                }
            }
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

        private void SaveUsersToServer(List<GeneralDTO> local_Users) throws IOException{
            //TODO: save updated users to local db
            URL get_users_url = new URL(server_url + "User/SaveUsers");
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
