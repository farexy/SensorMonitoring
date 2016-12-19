package ua.nure.sensormonitoring;

import android.app.Activity;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import ua.test.startup.testapp.R;

public class SubscriptionListView extends ArrayAdapter<String> {
    private ArrayList<String> ids;
    private ArrayList<String> names;
    private ArrayList<String> emails;
    private Activity context;

    public SubscriptionListView(Activity context, List<String> ids,
                                List<String> names,List<String> emails) {
        super(context, R.layout.list_view_layout, ids);
        this.context = context;
        this.ids = new ArrayList<>(ids);
        this.names = new ArrayList<>(names);
        this.emails = new ArrayList<>(emails);
    }


    @Override
    public long getItemId(int position) {
        return Long.parseLong(ids.get(position));
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = context.getLayoutInflater();
        View listViewItem = inflater.inflate(R.layout.list_view_layout, null, true);
        TextView textViewId = (TextView) listViewItem.findViewById(R.id.textViewId);
        TextView textViewName = (TextView) listViewItem.findViewById(R.id.textViewName);
        TextView textViewEmail = (TextView) listViewItem.findViewById(R.id.textViewEmail);

        textViewId.setText("ID:" + ids.get(position));
        textViewName.setText(names.get(position));
        textViewEmail.setText(emails.get(position));

        return listViewItem;
    }
}