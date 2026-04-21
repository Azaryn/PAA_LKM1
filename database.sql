CREATE TABLE users.status (
    id_status SERIAL PRIMARY KEY,
    nama_status VARCHAR(50) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE users.murid (
    id_murid SERIAL PRIMARY KEY,
    nama VARCHAR(255) NOT NULL,
    kelas VARCHAR(15),
    absen INTEGER,
    username VARCHAR(50) UNIQUE,
    password VARCHAR(255),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE users.status_murid (
    id_status_murid SERIAL PRIMARY KEY,
    id_status INTEGER REFERENCES users.status(id_status) ON DELETE CASCADE,
    id_murid INTEGER REFERENCES users.murid(id_murid) ON DELETE CASCADE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX idx_nama_murid ON users.murid(nama);
CREATE INDEX idx_username_murid ON users.murid(username);

INSERT INTO users.status (nama_status) VALUES 
('Ketua'),
('Wakil'),
('Sekretaris'),
('Bendahara'),
('Anggota');


INSERT INTO users.murid (nama, kelas, absen, username, password) VALUES
('Yanto', '12IPA1', 1, 'yanto', '123'),
('Kania', '12IPA2', 19, 'kania', '123'),
('Lubia', '12IPA3', 20, 'lubia', '123'),
('Rafi', '12IPA3', 26, 'rafi', '123'),
('Siti', '12IPA4', 1, 'siti', '123');

INSERT INTO users.status_murid (id_status, id_murid) VALUES
(1,1),
(1,2),
(1,3),
(2,4),
(3,6);