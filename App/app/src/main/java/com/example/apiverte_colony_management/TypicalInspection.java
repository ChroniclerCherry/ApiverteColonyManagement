package com.example.apiverte_colony_management;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.EditText;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Locale;

public class TypicalInspection extends AppCompatActivity {

    private  String[] population = {
            "Low", "low-medium", "medium", "medium-full", "full"
    };
    private  String[] mood = {
            "Calm", "nervous", "aggressive"
    };
    private  String[] fitness = {
            "Poor", "below-average", "average", "robust", "exceptional"
    };
    private  String[] broodChambers = {
            "1", "2", "3"
    };
    private  String[] honeyChamber = {
            "1", "2", "3"
    };
    private  String[] vents = {
            "None", "Upper", "Enterance", "Closed"
    };
    private  String[] broadPattern = {
            "Poor", "spotty", "pinhole", "solid"
    };
    private  String[] status = {
            "Queenright", "Queenless", "Time to Requeen", "Queen Replaced"
    };
    private  String[] cells = {
            "Emergency", "Supersedure", "Swarm", "Laying worked", "drone", "Youngest brood"
    };
    private  String[] swarmStatus = {
            "Not swarming", "Pre-swarming", "Swarming"
    };
    private  String[] excluder = {
            "yes", "no"
    };


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_typical_inspection);

        /*
        Automatically creates a current date and time
         */
        EditText autoD8 = (EditText)findViewById(R.id.autoDate);
        EditText autoTime = (EditText)findViewById(R.id.autoTime);

        SimpleDateFormat dateF = new SimpleDateFormat("EEE, d MMM yyyy", Locale.getDefault());
        SimpleDateFormat timeF = new SimpleDateFormat("HH:mm", Locale.getDefault());
        String date = dateF.format(Calendar.getInstance().getTime());
        String time = timeF.format(Calendar.getInstance().getTime());

        autoD8.setText(time);
        autoTime.setText(time);
    }
}