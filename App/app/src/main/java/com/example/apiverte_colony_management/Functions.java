package com.example.apiverte_colony_management;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;

public class Functions extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_functions);

        Button sign_in = findViewById(R.id.add_new_colony);

        sign_in.setOnClickListener( new View.OnClickListener()
        {   public void onClick(View v) {
            Intent goToAddNewColony = new Intent(Functions.this, CreateColonyPage.class);
            startActivity(goToAddNewColony);

        } });

        Button identifyColony = findViewById(R.id.typical_inspection);

            Intent goToIdentifyColony = new Intent(Functions.this, IdentifyColony.class);
            identifyColony.setOnClickListener(e -> {
                startActivity(goToIdentifyColony);
            });

            Log.i("WRONG", "Something is wrong here");
        }
    }
