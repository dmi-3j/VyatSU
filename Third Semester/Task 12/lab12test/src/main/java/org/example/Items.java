package org.example;

import javax.persistence.*;

@Entity
@Table(name = "items")
public class Items {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private long id;

    @Column(name = "val")
    public long val;

    @Version
    long version;

    public Items() {
        this.val = 0;
    }

//    public Items() {
//    }

    public long getVal() {
        return val;
    }

    public long getVersion() {
        return version;
    }

    public void setVal(long val) {
        this.val = val;
    }
}

