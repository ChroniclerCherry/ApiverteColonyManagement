package com.example.apiverte_colony_management;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.os.PersistableBundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.TextView;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

public class UpdateWithServer extends AppCompatActivity {

    private EditText server_url_textfield;
    private Button updateButton;
    private ProgressBar progressBar;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_update_server);

        SharedPreferences sharedPref = getApplicationContext().getSharedPreferences("server_url",Context.MODE_PRIVATE);
        String server_url = sharedPref.getString("url","https://localhost:4000/");

        server_url_textfield = findViewById(R.id.serverAddressTextField);
        server_url_textfield.setText(server_url);

        updateButton = findViewById(R.id.updateButton);
        progressBar = findViewById(R.id.progressBar);


    }
}
