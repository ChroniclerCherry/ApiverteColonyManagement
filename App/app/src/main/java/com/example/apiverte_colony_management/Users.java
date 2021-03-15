package com.example.apiverte_colony_management;

public class Users {
    private long id;
    private String userName;

    public Users() {}

    public Users(long id, String userName) {
        this.id = id;
        this.userName = userName;
    }

    public void setId(long id) {
        this.id = id;
    }

    public long getId() {
        return id;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public String getUserName() {
        return userName;
    }
}
