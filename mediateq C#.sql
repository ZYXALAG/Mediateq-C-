-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : mar. 12 déc. 2023 à 00:52
-- Version du serveur : 8.0.31
-- Version de PHP : 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

--
-- Base de données : `mediateq`
--

-- --------------------------------------------------------

--
-- Structure de la table `abonne`
--

DROP TABLE IF EXISTS `abonne`;
CREATE TABLE IF NOT EXISTS `abonne` (
  `IdAbonne` int NOT NULL AUTO_INCREMENT,
  `Nom` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `Prenom` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `Adresse` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `DateNaissance` date NOT NULL,
  `AdresseCourriel` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `NumeroTelephone` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `MotDePasse` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `DatePremierAbonnement` date NOT NULL,
  `DateFinAbonnement` date NOT NULL,
  `IdTypeAbonnement` int DEFAULT NULL,
  `chemin_image` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`IdAbonne`),
  KEY `FK_Abonne_TypeAbonnement` (`IdTypeAbonnement`)
);

--
-- Déchargement des données de la table `abonne`
--

INSERT INTO `abonne` (`IdAbonne`, `Nom`, `Prenom`, `Adresse`, `DateNaissance`, `AdresseCourriel`, `NumeroTelephone`, `MotDePasse`, `DatePremierAbonnement`, `DateFinAbonnement`, `IdTypeAbonnement`, `chemin_image`) VALUES
(1, 'NomTest', 'PrenomTest', '123 Rue de la Librairie', '2000-01-01', 'prenomTest.nomTest@email.com', '123456789', '010100JD', '2023-11-15', '2023-12-19', 3, ''),
(4, 'test', 'admin', '10 rue du test', '2023-11-02', 'admin@test.fr', '1919432324', '$2y$10$xZiiS5qjp089fm6bY9O0uOvWZx1ihV7AAqrk4uG9z.5ECdsT5wP62', '2023-11-15', '2023-11-30', 4, 'images/images_abonnes/test_4.png'),
(6, 'azea', 'aze', 'azeaz', '2023-11-08', 'test@test.fr', '24245252', '$2y$10$Do1hvW2VR9B/PNf6r8sPHubd5E1mmThkAr559y0IR7NJOCQhT13CK', '2023-11-12', '2023-11-15', 4, ''),
(7, 'Rulliat', 'Tomy', '19 rue vauban 69006 Lyon', '2004-08-05', 'tomy.rulliat@clsi.fr', '0768038691', '$2y$10$PDSYUKz.9GLUjwSk0NM1N.X5v2A0uyxStdyBddabE7TT3/.2PQ6Mu', '2023-11-15', '2028-07-20', 3, 'images/images_abonnes/Rulliat_7.jpg');

-- --------------------------------------------------------

--
-- Structure de la table `commande`
--

DROP TABLE IF EXISTS `commande`;
CREATE TABLE IF NOT EXISTS `commande` (
  `id` int NOT NULL,
  `nbExemplaire` int DEFAULT NULL,
  `dateCommande` date DEFAULT NULL,
  `montant` double DEFAULT NULL,
  `idDocument` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_1` (`idDocument`)
);

-- --------------------------------------------------------

--
-- Structure de la table `descripteur`
--

DROP TABLE IF EXISTS `descripteur`;
CREATE TABLE IF NOT EXISTS `descripteur` (
  `id` int NOT NULL,
  `libelle` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
);

--
-- Déchargement des données de la table `descripteur`
--

INSERT INTO `descripteur` (`id`, `libelle`) VALUES
(1, 'Presse économique'),
(2, 'Presse culturelle'),
(3, 'Presse sportive'),
(4, 'Presse loisir'),
(5, 'Presse Actualités'),
(10000, 'Humour'),
(10001, 'Bande dessinée'),
(10002, 'Science Fiction'),
(10003, 'Biographie'),
(10004, 'Historique'),
(10006, 'Roman'),
(10007, 'Aventures'),
(10008, 'Essai'),
(10009, 'Documentaire'),
(10010, 'Technique'),
(10011, 'Voyages'),
(10012, 'Drame'),
(10013, 'Comédie'),
(10014, 'Policier');

-- --------------------------------------------------------

--
-- Structure de la table `document`
--

DROP TABLE IF EXISTS `document`;
CREATE TABLE IF NOT EXISTS `document` (
  `id` int NOT NULL,
  `titre` varchar(50) DEFAULT NULL,
  `image` text,
  `commandeEnCours` int DEFAULT NULL,
  `idPublic` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_1` (`idPublic`)
);

--
-- Déchargement des données de la table `document`
--

INSERT INTO `document` (`id`, `titre`, `image`, `commandeEnCours`, `idPublic`) VALUES
(1, 'Quand sort la recluse', 'https://static.fnac-static.com/multimedia/Images/FR/NR/31/b0/84/8695857/1507-1/tsp20230105062957/Quand-sort-la-recluse.jpg', NULL, 2),
(2, 'Un pays à l\'aube', 'https://focus.telerama.fr/274x369/100/2021/08/19/-multimedia-images_produits-ZoomPE-7-6-3-9782743619367-tsp20130903072409-Un-pays-a-l-aube.jpg', NULL, 2),
(3, 'Et je danse aussi', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/61WW6LGkopL.jpg', NULL, 3),
(4, 'L\'armée furieuse', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/414cv83qQUL._SX307_BO1,204,203,200_.jpg', NULL, 2),
(5, 'Les anonymes', 'https://www.livredepoche.com/sites/default/files/styles/manual_crop_269_435/public/images/livres/couv/9782253157113-001-T.jpeg?itok=YjJE2a5e', NULL, 2),
(6, 'La marque jaune', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/91xG9uGkBBL.jpg', NULL, 3),
(7, 'Dans les coulisses du musée', 'https://www.livredepoche.com/sites/default/files/styles/manual_crop_269_435/public/images/livres/couv/9782253144908-001-T.jpeg?itok=mVyZ5mV6', NULL, 3),
(8, 'Histoire du juif errant', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/91mNV9BiLrL.jpg', NULL, 2),
(9, 'Pars vite et reviens tard', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/71FfPsoF65L.jpg', 0, 2),
(10, 'Le vestibule des causes perdues', 'https://www.babelio.com/couv/CVT_Le-vestibule-des-causes-perdues_4311.jpeg', 0, 2),
(11, 'L\'ile des oublies', 'https://www.livredepoche.com/sites/default/files/images/livres/couv/9782253161677-001-T.jpeg', 0, 2),
(12, 'La souris bleue', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/41QCZD0X+HS._SX307_BO1,204,203,200_.jpg', 0, 2),
(13, 'Sacré Pêre Noël', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/817UlBu9XML.jpg', 0, 2),
(14, 'Mauvaise étoile', 'https://www.livredepoche.com/sites/default/files/styles/manual_crop_269_435/public/images/livres/couv/9782253176077-001-T.jpeg?itok=qP8a2k-X', 0, 2),
(15, 'La confrérie des téméraires', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/715vQyw5GFL.jpg', 0, 2),
(16, 'Le butin du requin', 'https://www.actes-sud.fr/sites/default/files/couvertures/9782330121877.jpg', 0, 2),
(17, 'Catastrophes au Brésil', 'https://static.fnac-static.com/multimedia/Images/FR/NR/dd/ea/6d/7203549/1507-1/tsp20230221075906/Les-39-cles-Cahill-contre-Vesper.jpg', 0, 2),
(18, 'Le Routard - Maroc', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/91j1+5tonlL.jpg', 0, 2),
(19, 'Guide Vert - Iles Canaries', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/81vH6kVUOML.jpg', 0, 2),
(20, 'Guide Vert - Irlande', 'https://static.fnac-static.com/multimedia/Images/FR/NR/c2/f7/ad/11401154/1507-1/tsp20220418082938/Guide-Vert-Irlande.jpg', 0, 2),
(21, 'Les déferlantes', 'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/41XbNQNHHEL._SX307_BO1,204,203,200_.jpg', 0, 2),
(22, 'Une part de Ciel', 'https://static.fnac-static.com/multimedia/Images/FR/NR/b8/0e/7c/8130232/1507-1/tsp20210114102306/Une-part-de-ciel.jpg', 0, 2),
(23, 'Le secret du janissaire', 'https://www.bedetheque.com/media/Couvertures/Couv_270396.jpg', 0, 2),
(24, 'Pavillon noir', 'https://images.epagine.fr/430/9782840551430_1_75.jpg', 0, 2),
(25, 'L\'archipel du danger', 'https://cdn.cultura.com/cdn-cgi/image/width=768/media/pim/TITELIVE/35_9782840552369_1_75.jpg', 0, 2),
(26, 'Agence tout risques', 'https://fr.web.img5.acsta.net/medias/nmedia/18/73/05/71/19447495.jpg', NULL, 3),
(31, 'Le Retour de l\'Aventure', '', NULL, 1),
(32, 'Le Retour de l\'Amour', '', NULL, 2),
(33, 'Le Retour de l\'Intrigue', '', NULL, 3),
(34, 'Le Retour de l\'Action', '', NULL, 4),
(35, 'Le Retour de la Comédie', '', NULL, 1),
(36, 'Le Retour de la Romance', '', NULL, 2),
(37, 'Le Retour du Mystère', '', NULL, 3),
(38, 'Le Retour de l\'Héroïsme', '', NULL, 4),
(39, 'Le Retour de la Fantaisie', '', NULL, 1),
(40, 'Le Retour de l\'Émotion', '', NULL, 2),
(41, 'Le Retour de l\'Espionnage', '', NULL, 3),
(42, 'Le Retour de la Science-Fiction', '', NULL, 4),
(43, 'Le Retour de la Magie', '', NULL, 1),
(44, 'Le Retour de la Musique', '', NULL, 2),
(45, 'Le Retour de l\'Humour', '', NULL, 3),
(10001, 'Arts Magazine - Numéro 1', 'https://cdn.cultura.com/cdn-cgi/image/width=768/media/pim/TITELIVE/35_9782840552369_1_75.jpg', NULL, 3),
(10002, 'Revue Test 2', '', NULL, 3);

-- --------------------------------------------------------

--
-- Structure de la table `documentliste`
--

DROP TABLE IF EXISTS `documentliste`;
CREATE TABLE IF NOT EXISTS `documentliste` (
  `idListe` int NOT NULL,
  `idDocument` int NOT NULL,
  PRIMARY KEY (`idDocument`,`idListe`) USING BTREE,
  KEY `idListe` (`idListe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `documentliste`
--

INSERT INTO `documentliste` (`idListe`, `idDocument`) VALUES
(1, 8),
(1, 11),
(3, 5);

-- --------------------------------------------------------

--
-- Structure de la table `dvd`
--

DROP TABLE IF EXISTS `dvd`;
CREATE TABLE IF NOT EXISTS `dvd` (
  `idDocument` int NOT NULL,
  `synopsis` varchar(100) DEFAULT NULL,
  `réalisateur` varchar(50) DEFAULT NULL,
  `duree` smallint DEFAULT NULL,
  PRIMARY KEY (`idDocument`)
);

--
-- Déchargement des données de la table `dvd`
--

INSERT INTO `dvd` (`idDocument`, `synopsis`, `réalisateur`, `duree`) VALUES
(26, 'une agence qui prend tout les risques', 'c pas moa', 240),
(31, 'Une aventure passionnante vous attend', 'Director A', 120),
(32, 'L\'amour revient avec des surprises', 'Director B', 110),
(33, 'Intrigue captivante avec des retournements', 'Director C', 130),
(34, 'Action palpitante et rebondissements', 'Director D', 125),
(35, 'Comédie hilarante pour toute la famille', 'Director E', 105),
(36, 'Romance envoûtante dans un cadre magnifique', 'Director F', 115),
(37, 'Mystère qui vous tiendra en haleine', 'Director G', 140),
(38, 'Héroïsme dans un monde fantastique', 'Director H', 135),
(39, 'Fantaisie épique avec des créatures magiques', 'Director I', 150),
(40, 'Émotion pure et moments inoubliables', 'Director J', 128),
(41, 'Espionnage intense avec des rebondissements', 'Director K', 122),
(42, 'Science-Fiction futuriste et captivante', 'Director L', 160),
(43, 'Magie et mystère se conjuguent', 'Director M', 138),
(44, 'Musique enchanteresse et mémorable', 'Director N', 118),
(45, 'Humour qui vous fera éclater de rire', 'Director O', 100);

-- --------------------------------------------------------

--
-- Structure de la table `emprunt`
--

DROP TABLE IF EXISTS `emprunt`;
CREATE TABLE IF NOT EXISTS `emprunt` (
  `idAbonne` int NOT NULL,
  `idDocument` int NOT NULL,
  `dateDebut` date NOT NULL,
  `dateFin` date NOT NULL,
  `prolongeable` tinyint(1) NOT NULL,
  `Lieu` varchar(255) NOT NULL,
  `Termine` tinyint(1) NOT NULL,
  PRIMARY KEY (`idAbonne`,`idDocument`) USING BTREE,
  KEY `idAbonne` (`idAbonne`),
  KEY `idDocument` (`idDocument`)
);

--
-- Déchargement des données de la table `emprunt`
--

INSERT INTO `emprunt` (`idAbonne`, `idDocument`, `dateDebut`, `dateFin`, `prolongeable`, `Lieu`, `Termine`) VALUES
(4, 1, '2023-12-13', '2023-12-29', 0, 'Versailles', 1),
(4, 2, '2023-12-13', '2023-12-29', 0, 'Versailles', 0),
(4, 3, '2023-12-13', '2023-12-29', 0, 'Versailles', 1),
(4, 10, '2023-12-06', '2024-02-16', 1, 'fff', 0),
(4, 18, '2023-12-13', '2023-12-29', 0, 'Versailles', 1),
(4, 25, '2023-12-13', '2024-01-05', 1, 'Versailles', 0);

-- --------------------------------------------------------

--
-- Structure de la table `est_decrit_par_2`
--

DROP TABLE IF EXISTS `est_decrit_par_2`;
CREATE TABLE IF NOT EXISTS `est_decrit_par_2` (
  `idDocument` int NOT NULL,
  `idDescripteur` int NOT NULL,
  PRIMARY KEY (`idDocument`,`idDescripteur`),
  KEY `id_1` (`idDescripteur`)
);

--
-- Déchargement des données de la table `est_decrit_par_2`
--

INSERT INTO `est_decrit_par_2` (`idDocument`, `idDescripteur`) VALUES
(3, 10006),
(1, 10008),
(3, 10011),
(1, 10014);

-- --------------------------------------------------------

--
-- Structure de la table `etat`
--

DROP TABLE IF EXISTS `etat`;
CREATE TABLE IF NOT EXISTS `etat` (
  `id` int NOT NULL,
  `libelle` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
);

--
-- Déchargement des données de la table `etat`
--

INSERT INTO `etat` (`id`, `libelle`) VALUES
(1, 'neuf'),
(2, 'usagé'),
(3, 'détérioré'),
(4, 'inutilisable');

-- --------------------------------------------------------

--
-- Structure de la table `exemplaire`
--

DROP TABLE IF EXISTS `exemplaire`;
CREATE TABLE IF NOT EXISTS `exemplaire` (
  `idDocument` int NOT NULL,
  `numero` int NOT NULL,
  `dateAchat` date DEFAULT NULL,
  `idRayon` int NOT NULL,
  `idEtat` int NOT NULL,
  PRIMARY KEY (`idDocument`,`numero`),
  KEY `id` (`idRayon`),
  KEY `id_1` (`idEtat`)
);

--
-- Déchargement des données de la table `exemplaire`
--

INSERT INTO `exemplaire` (`idDocument`, `numero`, `dateAchat`, `idRayon`, `idEtat`) VALUES
(1, 1, '2023-01-15', 1, 1),
(1, 2, '2023-02-20', 2, 2),
(1, 3, '2023-03-10', 3, 3),
(2, 1, '2023-07-02', 1, 1),
(3, 1, '2023-04-05', 2, 1),
(3, 2, '2023-05-12', 3, 2),
(3, 3, '2023-06-08', 1, 3),
(3, 4, '2023-11-10', 2, 2),
(4, 1, '2023-07-15', 2, 2),
(6, 1, '2023-07-20', 3, 3),
(8, 1, '2023-08-05', 1, 1),
(10, 1, '2023-08-10', 2, 2),
(12, 1, '2023-08-15', 3, 3),
(14, 1, '2023-09-02', 1, 1),
(16, 1, '2023-09-10', 2, 2),
(18, 1, '2023-09-15', 3, 3),
(20, 1, '2023-10-05', 1, 1),
(22, 1, '2023-10-10', 2, 2),
(24, 1, '2023-10-15', 3, 3),
(26, 1, '2023-11-02', 1, 1),
(10001, 2, '0000-00-00', 4, 1);

-- --------------------------------------------------------

--
-- Structure de la table `liste`
--

DROP TABLE IF EXISTS `liste`;
CREATE TABLE IF NOT EXISTS `liste` (
  `idListe` int NOT NULL,
  `idAbonne` int NOT NULL,
  `nom` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`idListe`),
  KEY `idAbonne` (`idAbonne`)
);

--
-- Déchargement des données de la table `liste`
--

INSERT INTO `liste` (`idListe`, `idAbonne`, `nom`) VALUES
(1, 4, 'Favoris'),
(3, 1, 'Test');

-- --------------------------------------------------------

--
-- Structure de la table `livre`
--

DROP TABLE IF EXISTS `livre`;
CREATE TABLE IF NOT EXISTS `livre` (
  `idDocument` int NOT NULL,
  `ISBN` char(13) DEFAULT NULL,
  `auteur` varchar(50) DEFAULT NULL,
  `collection` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idDocument`)
);

--
-- Déchargement des données de la table `livre`
--

INSERT INTO `livre` (`idDocument`, `ISBN`, `auteur`, `collection`) VALUES
(1, '1234569877896', 'Fred Vargas', 'Commissaire Adamsberg'),
(2, '1236547896541', 'Dennis Lehanne', ''),
(3, '6541236987410', 'Anne-Laure Bondoux', ''),
(4, '3214569874123', 'Fred Vargas', 'Commissaire Adamsberg'),
(5, '3214563214563', 'RJ Ellory', ''),
(6, '3213213211232', 'Edgar P. Jacobs', 'Blake et Mortimer'),
(7, '6541236987541', 'Kate Atkinson', ''),
(8, '1236987456321', 'Jean d\'Ormesson', ''),
(9, '3,21E+12', 'Fred Vargas', 'Commissaire Adamsberg'),
(10, '3,21E+12', 'Manon Moreau', ''),
(11, '3,21E+12', 'Victoria Hislop', ''),
(12, '3,21E+12', 'Kate Atkinson', ''),
(13, '3,21E+12', 'Raymond Briggs', ''),
(14, '3,21E+12', 'RJ Ellory', ''),
(15, '3,21E+12', 'Floriane Turmeau', ''),
(16, '3,21E+12', 'Julian Press', ''),
(17, '3,21E+12', 'Philippe Masson', ''),
(18, '3,21E+12', '', 'Guide du Routard'),
(19, '3,21E+12', '', 'Guide Vert'),
(20, '3,21E+12', '', 'Guide Vert'),
(21, '3,21E+12', 'Claudie Gallay', ''),
(22, '3,21E+12', 'Claudie Gallay', ''),
(23, '3,21E+12', 'Ayrolles - Masbou', 'De cape et de crocs'),
(24, '3,21E+12', 'Ayrolles - Masbou', 'De cape et de crocs'),
(25, '3,21E+12', 'Ayrolles - Masbou', 'De cape et de crocs');

-- --------------------------------------------------------

--
-- Structure de la table `parution`
--

DROP TABLE IF EXISTS `parution`;
CREATE TABLE IF NOT EXISTS `parution` (
  `idRevue` int NOT NULL,
  `numero` int NOT NULL,
  `dateParution` date DEFAULT NULL,
  `photo` varchar(500) DEFAULT NULL,
  `idEtat` int NOT NULL,
  PRIMARY KEY (`idRevue`,`numero`),
  KEY `id` (`idEtat`)
);

--
-- Déchargement des données de la table `parution`
--

INSERT INTO `parution` (`idRevue`, `numero`, `dateParution`, `photo`, `idEtat`) VALUES
(10001, 154, '2021-07-01', NULL, 1),
(10001, 155, '2021-08-01', NULL, 1),
(10001, 156, '2021-09-01', NULL, 1),
(10001, 157, '2021-10-01', NULL, 1),
(10001, 158, '2021-11-01', NULL, 1),
(10001, 159, '2021-12-01', NULL, 1),
(10001, 160, '2023-01-01', 'lien vers la photo de janvier 2023', 1),
(10001, 161, '2023-02-01', 'lien vers la photo de février 2023', 1),
(10002, 2154, '2021-07-01', 'lien vers la photo de juillet 2021', 1),
(10002, 2155, '2021-08-01', NULL, 1),
(10002, 2156, '2021-09-01', NULL, 1),
(10002, 2157, '2021-10-01', NULL, 1),
(10002, 2158, '2021-11-01', NULL, 1),
(10002, 2159, '2021-12-01', NULL, 1),
(10002, 2160, '2023-01-01', 'lien vers la photo de janvier 2023', 1),
(10002, 2161, '2023-02-01', 'lien vers la photo de février 2023', 1),
(10003, 215, '2021-02-01', NULL, 1),
(10003, 216, '2021-03-01', NULL, 1),
(10003, 217, '2021-04-01', NULL, 1),
(10003, 218, '2021-05-01', NULL, 1),
(10003, 219, '2021-06-01', NULL, 1),
(10003, 220, '2021-07-01', NULL, 1),
(10003, 221, '2023-01-15', 'lien vers la photo de janvier 2023', 1),
(10003, 222, '2023-02-15', 'lien vers la photo de février 2023', 1),
(10004, 163, '2023-01-10', 'lien vers la photo de janvier 2023', 1),
(10004, 164, '2023-02-10', 'lien vers la photo de février 2023', 1),
(10005, 323, '2023-01-20', 'lien vers la photo de janvier 2023', 1),
(10005, 324, '2023-02-20', 'lien vers la photo de février 2023', 1),
(10005, 3215, '2021-11-20', NULL, 1),
(10005, 3216, '2021-11-21', NULL, 1),
(10005, 3217, '2021-11-22', NULL, 1),
(10005, 3218, '2021-11-23', NULL, 1),
(10005, 3219, '2021-11-24', NULL, 1),
(10005, 3220, '2021-11-25', NULL, 1),
(10006, 223, '2023-01-05', 'lien vers la photo de janvier 2023', 1),
(10006, 224, '2023-02-05', 'lien vers la photo de février 2023', 1),
(10007, 163, '2023-01-08', 'lien vers la photo de janvier 2023', 1),
(10007, 164, '2023-02-08', 'lien vers la photo de février 2023', 1),
(10008, 223, '2023-01-02', 'lien vers la photo de janvier 2023', 1),
(10008, 224, '2023-02-02', 'lien vers la photo de février 2023', 1),
(10009, 163, '2023-01-02', 'lien vers la photo de janvier 2023', 1),
(10009, 164, '2023-02-02', 'lien vers la photo de février 2023', 1),
(10010, 323, '2023-01-03', 'lien vers la photo de janvier 2023', 1),
(10010, 324, '2023-02-03', 'lien vers la photo de février 2023', 1),
(10011, 223, '2023-01-01', 'lien vers la photo de janvier 2023', 1),
(10011, 224, '2023-02-01', 'lien vers la photo de février 2023', 1);

-- --------------------------------------------------------

--
-- Structure de la table `public`
--

DROP TABLE IF EXISTS `public`;
CREATE TABLE IF NOT EXISTS `public` (
  `id` int NOT NULL,
  `libelle` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
);

--
-- Déchargement des données de la table `public`
--

INSERT INTO `public` (`id`, `libelle`) VALUES
(1, 'Jeunesse'),
(2, 'Adultes'),
(3, 'Tous publics'),
(4, 'Ados');

-- --------------------------------------------------------

--
-- Structure de la table `rayon`
--

DROP TABLE IF EXISTS `rayon`;
CREATE TABLE IF NOT EXISTS `rayon` (
  `id` int NOT NULL,
  `libelle` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
);

--
-- Déchargement des données de la table `rayon`
--

INSERT INTO `rayon` (`id`, `libelle`) VALUES
(1, 'Romans'),
(2, 'Science-fiction'),
(3, 'Policier'),
(4, 'Jeunesse'),
(5, 'Biographie');

-- --------------------------------------------------------

--
-- Structure de la table `reservation`
--

DROP TABLE IF EXISTS `reservation`;
CREATE TABLE IF NOT EXISTS `reservation` (
  `idReservation` int NOT NULL AUTO_INCREMENT,
  `idAbonne` int NOT NULL,
  `idDocument` int NOT NULL,
  `numeroExemplaire` int NOT NULL,
  `dateDemande` date NOT NULL,
  PRIMARY KEY (`idReservation`)
);

--
-- Déchargement des données de la table `reservation`
--

INSERT INTO `reservation` (`idReservation`, `idAbonne`, `idDocument`, `numeroExemplaire`, `dateDemande`) VALUES
(56, 4, 8, 1, '2023-12-10');

-- --------------------------------------------------------

--
-- Structure de la table `revue`
--

DROP TABLE IF EXISTS `revue`;
CREATE TABLE IF NOT EXISTS `revue` (
  `id` int NOT NULL,
  `titre` varchar(50) NOT NULL,
  `empruntable` char(1) DEFAULT NULL,
  `periodicite` varchar(2) DEFAULT NULL,
  `delai_miseadispo` int DEFAULT NULL,
  `dateFinAbonnement` date DEFAULT NULL,
  `idDescripteur` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_1` (`idDescripteur`)
);

--
-- Déchargement des données de la table `revue`
--

INSERT INTO `revue` (`id`, `titre`, `empruntable`, `periodicite`, `delai_miseadispo`, `dateFinAbonnement`, `idDescripteur`) VALUES
(10001, 'Arts Magazine', 'O', 'MS', 52, '2024-02-12', 2),
(10002, 'Alternatives Economiques', 'O', 'HB', 52, '2022-04-30', 1),
(10003, 'Challenges', 'O', 'HB', 26, '2022-02-28', 1),
(10004, 'Rock and Folk', 'O', 'MS', 52, '2022-10-31', 2),
(10005, 'Les Echos', 'N', 'QT', 5, '2022-12-31', 1),
(10006, 'L\'Equipe', 'N', 'QT', 5, '2022-01-31', 3),
(10007, 'Telerama', 'O', 'HB', 26, '2022-01-31', 2),
(10008, 'L\'Obs', 'O', 'HB', 26, '2022-01-31', 5),
(10009, 'Le Monde', 'N', 'QT', 5, '2022-01-31', 5),
(10010, 'L\'Equipe Magazine', 'O', 'HB', 12, '2022-01-31', 3),
(10011, 'Geo', 'O', 'MS', 52, '2022-01-31', 2);

-- --------------------------------------------------------

--
-- Structure de la table `service`
--

DROP TABLE IF EXISTS `service`;
CREATE TABLE IF NOT EXISTS `service` (
  `id_service` int NOT NULL,
  `role` varchar(20) NOT NULL,
  PRIMARY KEY (`id_service`)
);

--
-- Déchargement des données de la table `service`
--

INSERT INTO `service` (`id_service`, `role`) VALUES
(0, 'administratif'),
(1, 'prêt'),
(2, 'culture');

-- --------------------------------------------------------

--
-- Structure de la table `type_abonnement`
--

DROP TABLE IF EXISTS `type_abonnement`;
CREATE TABLE IF NOT EXISTS `type_abonnement` (
  `IdTypeAbonnement` int NOT NULL,
  `Libelle` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `NombreDocuments` int NOT NULL,
  `DureeSemaines` int NOT NULL,
  PRIMARY KEY (`IdTypeAbonnement`),
  UNIQUE KEY `UC_TypeAbonnement_Libelle` (`Libelle`)
);

--
-- Déchargement des données de la table `type_abonnement`
--

INSERT INTO `type_abonnement` (`IdTypeAbonnement`, `Libelle`, `NombreDocuments`, `DureeSemaines`) VALUES
(1, 'Junior', 20, 3),
(2, 'Jeune', 20, 3),
(3, 'Adulte', 20, 3),
(4, 'Educateur', 20, 6);

-- --------------------------------------------------------

--
-- Structure de la table `utilisateurs`
--

DROP TABLE IF EXISTS `utilisateurs`;
CREATE TABLE IF NOT EXISTS `utilisateurs` (
  `id_utilisateur` int NOT NULL AUTO_INCREMENT,
  `login` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `nom` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `prenom` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `mot_de_passe` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `service` int NOT NULL,
  `salt` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id_utilisateur`)
);

--
-- Déchargement des données de la table `utilisateurs`
--

INSERT INTO `utilisateurs` (`id_utilisateur`, `login`, `nom`, `prenom`, `mot_de_passe`, `service`, `salt`) VALUES
(1, 'AdministratifTest', 'Administratif', 'Test', 'Q7yRSp3BwX/iywOzEZcotdIRVVkyn1GsWvsW4A90YWk=', 2, 'jQOmYEVF8dmXEVmBZ2gPuA=='),
(2, 'adminTest', 'Admin', 'Test', '/2kV/bpMSqpWWlM244a6xYZ1XNcStd2O2n4rm7YUmYs=', 0, '//eHA31KHYn3tQIZV776PQ=='),
(3, 'PretTest', 'Pret', 'Test', 'qzYLSlxCf4IuSKFulkhrH4nIHKrT0q/+F8KUwpIm9lo=', 1, 'bIzytgG8Psu52i5fYQE87g=='),
(4, 'CultureTest', 'Culture', 'Test', 'iU1T7KzCte+btzr6dt05SdEQ2FuVFI4lQXg1yRKMXT8=', 2, '/MDI8PMhOlI4yx1p452yhg=='),
(5, 'test@test.fr', 'Leschaeve', 'Adrien', 'sachDgvLHLApwTpyFqdGpbJULq3h+39kJpwpw7Rg1aY=', 0, '5wiyFiGDJ86vEaoi+I60SA==');

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `commande`
--
ALTER TABLE `commande`
  ADD CONSTRAINT `commande_ibfk_1` FOREIGN KEY (`idDocument`) REFERENCES `document` (`id`);

--
-- Contraintes pour la table `document`
--
ALTER TABLE `document`
  ADD CONSTRAINT `document_ibfk_1` FOREIGN KEY (`idPublic`) REFERENCES `public` (`id`);

--
-- Contraintes pour la table `documentliste`
--
ALTER TABLE `documentliste`
  ADD CONSTRAINT `documentliste_ibfk_2` FOREIGN KEY (`idDocument`) REFERENCES `document` (`id`),
  ADD CONSTRAINT `documentliste_ibfk_3` FOREIGN KEY (`idListe`) REFERENCES `liste` (`idListe`);

--
-- Contraintes pour la table `dvd`
--
ALTER TABLE `dvd`
  ADD CONSTRAINT `dvd_ibfk_1` FOREIGN KEY (`idDocument`) REFERENCES `document` (`id`);

--
-- Contraintes pour la table `emprunt`
--
ALTER TABLE `emprunt`
  ADD CONSTRAINT `emprunt_ibfk_1` FOREIGN KEY (`idDocument`) REFERENCES `document` (`id`),
  ADD CONSTRAINT `fk_emprunt_abonne` FOREIGN KEY (`idAbonne`) REFERENCES `abonne` (`IdAbonne`);

--
-- Contraintes pour la table `est_decrit_par_2`
--
ALTER TABLE `est_decrit_par_2`
  ADD CONSTRAINT `est_decrit_par_2_ibfk_1` FOREIGN KEY (`idDocument`) REFERENCES `document` (`id`),
  ADD CONSTRAINT `est_decrit_par_2_ibfk_2` FOREIGN KEY (`idDescripteur`) REFERENCES `descripteur` (`id`);

--
-- Contraintes pour la table `exemplaire`
--
ALTER TABLE `exemplaire`
  ADD CONSTRAINT `exemplaire_ibfk_1` FOREIGN KEY (`idDocument`) REFERENCES `document` (`id`),
  ADD CONSTRAINT `exemplaire_ibfk_2` FOREIGN KEY (`idRayon`) REFERENCES `rayon` (`id`),
  ADD CONSTRAINT `exemplaire_ibfk_3` FOREIGN KEY (`idEtat`) REFERENCES `etat` (`id`);

--
-- Contraintes pour la table `liste`
--
ALTER TABLE `liste`
  ADD CONSTRAINT `liste_ibfk_1` FOREIGN KEY (`idAbonne`) REFERENCES `abonne` (`IdAbonne`);

--
-- Contraintes pour la table `livre`
--
ALTER TABLE `livre`
  ADD CONSTRAINT `livre_ibfk_1` FOREIGN KEY (`idDocument`) REFERENCES `document` (`id`);

--
-- Contraintes pour la table `parution`
--
ALTER TABLE `parution`
  ADD CONSTRAINT `parution_ibfk_1` FOREIGN KEY (`idRevue`) REFERENCES `revue` (`id`),
  ADD CONSTRAINT `parution_ibfk_2` FOREIGN KEY (`idEtat`) REFERENCES `etat` (`id`);

--
-- Contraintes pour la table `revue`
--
ALTER TABLE `revue`
  ADD CONSTRAINT `revue_ibfk_2` FOREIGN KEY (`idDescripteur`) REFERENCES `descripteur` (`id`);
COMMIT;