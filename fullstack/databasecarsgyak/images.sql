-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Host: db:3306
-- Generation Time: Oct 02, 2026 at 06:08 AM
-- Server version: 9.7.1
-- PHP Version: 8.3.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

--
-- Database: `laravel`
--

-- --------------------------------------------------------

--
-- Table structure for table `images`
--

CREATE TABLE `images` (
  `id` bigint UNSIGNED NOT NULL,
  `image_id` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `repository` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `tag` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT '',
  `created` datetime NOT NULL,
  `size` int UNSIGNED NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `images`
--

INSERT INTO `images` (`id`, `image_id`, `repository`, `tag`, `created`, `size`, `created_at`, `updated_at`) VALUES
(1, '53693e9d29f224caf7db039abd45eea46b686b8c078747a161e861fd967aed48', 'rcsnjszg/backend', '2627', '2026-08-18 11:10:50', 976, NULL, NULL),
(2, '319a90595f326f1dc1f17c61527a493cb4b54bb8e83af6211fcc90c2e1b5b06d', 'rcsnjszg/phpapp2627', 'latest', '2026-08-18 11:10:50', 976, NULL, NULL),
(3, 'd93aaa3a0130bfda769ddbbe6d79426199984d13676b88ff24c1fef184fb225e', 'idomi27/vue', '2627', '2026-08-18 11:09:29', 316, NULL, NULL),
(4, '08f9812400ab2af5ed1136450ec5d6230f58f3ed2023d898d02375a9d0e14c37', 'idomi27/json-server', '2627', '2026-08-18 11:09:15', 17, NULL, NULL),
(5, '146859216248034da55987f13e0d1cc85e8e43a76be5e7a332d208f4c5a9eb15', 'rcsnjszg/phpmyadmin', '5.2.3-apache', '2026-08-18 10:17:16', 876, NULL, NULL),
(6, 'bf3a5f0b49ded2d7144bfd5846eeb08b3315975e6c5f1acb1a01f678720477ac', 'docs/shadcn', 'latest', '2026-08-18 08:32:55', 2263, NULL, NULL),
(7, 'f891930a6f35079a3dbb9c2e13d8849a1fac9cb652d5c84194db616457906baf', 'docs/tailwind', 'latest', '2026-08-18 00:27:43', 562, NULL, NULL),
(8, '6db441d171023a3ff26bd98417899ca8d7bee46f679c734add4ee9762276f154', 'docs/vue-router', 'latest', '2026-08-18 00:25:18', 124, NULL, NULL),
(9, '14f5636b8512c431002b798f7676e0647024632723cc6a06109cd8e62c3ac70d', 'docs/pinia', 'latest', '2026-08-18 00:21:44', 106, NULL, NULL),
(10, 'cb226a8c37aa5e209d15071d7a90f39eae5af9f915bec00f57bd1a85b241c4bd', 'docs/mdn', 'latest', '2026-08-18 00:21:00', 1823, NULL, NULL),
(11, '4b9a42f606a87bf5f72bbe8ff6247d183d7c72d171db1754beeed37068868e59', 'docs/vue', 'latest', '2026-08-18 00:19:55', 132, NULL, NULL),
(12, 'beaad586521cdc5541629899114bd0742a03e9f1661c3de9a45fe17313239db8', 'docs/laravel', 'latest', '2026-08-18 00:16:09', 107, NULL, NULL),
(13, '8b6175f6c6b89aaf31ffdace4a22d17715c07f1cf3a772dadb10c658f779e23d', 'dart', 'stable', '2026-08-12 19:26:48', 1239, NULL, NULL),
(14, 'c4717a8d1f0134a7444e24f881160e033991f23027c6c5a9a3f8fd22e70d1d44', 'traefik/whoami', 'v1.12.0', '2026-07-29 17:43:04', 19, NULL, NULL),
(15, '66aec17cd21a956029b83f083b813073859e8355dc1a00e55df6ba02f0e32345', 'mysql', 'latest', '2026-07-28 00:08:24', 1331, NULL, NULL),
(16, 'b4d933c7185b5cc9da7704f2c6e19d477f935ea31a50d9a017ffce2bbd1109a3', 'alpine/git', 'v2.54.0', '2026-07-26 08:31:48', 143, NULL, NULL),
(17, 'f80ef446483381a53c981e322b2497f904a14c6f8ff142a787a52cd96acf1f0c', 'hurlenko/filebrowser', 'v2.63.20', '2026-07-26 03:21:47', 65, NULL, NULL),
(18, '652929a140a32d7cafafb13c6cdfab5376cfeff800f51397b87b524501ed02a8', 'traefik', '3.7.9', '2026-07-24 21:31:24', 250, NULL, NULL),
(19, '652929a140a32d7cafafb13c6cdfab5376cfeff800f51397b87b524501ed02a8', 'traefik', 'v3.7.9', '2026-07-24 21:31:24', 250, NULL, NULL),
(20, 'c88d347edef6249a6d2293f926f1eeb48bd40c57cbcd02c07f52e7f1fd2cb46b', 'redis', '8.8.1-trixie', '2026-07-24 19:21:06', 208, NULL, NULL),
(21, '691c8e0560a807a4affefbcf7e729716b372d1df7c57e18ed3a263044cf45908', 'lscr.io/linuxserver/code-server', 'latest', '2026-07-24 07:00:12', 1229, NULL, NULL),
(22, 'f00cf053b49a6b3a2f7509a4a4f771749773a5625bb95d82944f8405de5dd161', 'swaggerapi/swagger-editor', 'v5.8.3', '2026-07-22 14:41:47', 200, NULL, NULL),
(23, 'e43eb34b978af58d8cb78e5da9c12d605cf43d113ad3a96b18f9b028d6479d68', 'swaggerapi/swagger-ui', 'v5.32.11', '2026-07-22 09:33:53', 199, NULL, NULL),
(24, 'fe59f2cac5c7451644c8780cb2fb6735fde512d06642117199a7479269702f03', 'cypress/included', 'cypress-15.19.0-node-24.18.0-chrome-150.0.7871.128-1-ff-153.0-edge-150.0.4078.83-1', '2026-07-21 20:01:37', 4813, NULL, NULL),
(25, 'c032a38048fda20b96b5599821ed4fae4c0cf3c18068f17a0d6dd81a9794c432', 'keinos/sqlite3', '3.53.3', '2026-07-21 02:46:38', 15, NULL, NULL),
(26, 'b87aba3079ad6ffb50d4f320a2f2ca945b684c8a38bd54ff032c9a02f4461a67', 'wordpress', '7.0.2-php8.4-apache', '2026-07-20 20:14:06', 1126, NULL, NULL),
(27, '494d4a9461105644222c938679fe58d5e3fd13fb228c76a426e81c16d4ffbaef', 'adminer', '5.5.0-standalone', '2026-07-17 21:16:48', 164, NULL, NULL),
(28, 'a2f437961ca7ac19cddea655efc8a0b5f5d5fc13580869ea1654ff5663ef9943', 'selenium/node-firefox', '152.0-geckodriver-0.37-grid-4.46.0-20260707', '2026-07-16 07:38:56', 3133, NULL, NULL),
(29, '4a4689d68468d33b6b5321e59c7d9d8301ebb21006829347ae373248ee984fb2', 'selenium/node-chrome', '150.0.7871.124-chromedriver-150.0.7871.124', '2026-07-16 07:27:43', 3257, NULL, NULL),
(30, 'ede6ae4d5b34a2321dfdc922d82b88b885883ece764fb1ea16dc2fafb8b03125', 'selenium/hub', '4.46.0-20260707', '2026-07-16 07:00:15', 1055, NULL, NULL),
(31, '4a73073bd557c65b759505da037898b61f1be6cbcc3c2c3aeac22d2a470c1752', 'nginx', '1.31.3-alpine3.24', '2026-07-16 01:57:33', 94, NULL, NULL),
(32, '45b82ed5f285b90d63df07ba70430fdd8f25624b416617d9e6dc93412b2006dc', 'nginx', 'alpine3.24-slim', '2026-07-16 01:31:20', 21, NULL, NULL),
(33, '4299bbed850421258fc5448c2e0e6ad350981d4d335a68de11b92448aedbefe5', 'traefik', 'v3.7.8', '2026-07-15 19:38:14', 250, NULL, NULL),
(34, 'b13aae2cab3b2857e9690811fc80b342c8f5103c38843bb43424379690cbffe9', 'joomla', '6.1.2-php8.4-apache', '2026-07-14 04:36:00', 1188, NULL, NULL),
(35, 'b68f318c5fd85541795ed8eb4ced28ea6908a89910871783b3e479cc6c6d1e1b', 'phpmyadmin', '5.2.3-apache', '2026-07-14 04:28:27', 821, NULL, NULL),
(36, '76f447018df51801eb0587bdced331709c2d7ac4e0bb8b9cb00bd4f93dd85d1c', 'php', '8.5.8-apache-bookworm', '2026-07-14 03:29:17', 746, NULL, NULL),
(37, 'ed034a8bf0b24ded0cbbac07e17825d8e9ebfe21e308191d0f7421eaf5ad4664', 'mcr.microsoft.com/dotnet/sdk', '10.0', '2026-07-14 02:52:40', 1280, NULL, NULL),
(38, '1fa23fc4872d95fd71c2833ebe65d7e84a43b2d51a31d119516852f13d9505a7', 'mcr.microsoft.com/dotnet/aspnet', '10.0', '2026-07-14 02:51:26', 340, NULL, NULL),
(39, 'ed5d539b27842d656a06a5984dbcb5114d3e885fbada612a49a5a7c3c3a44e1c', 'mcr.microsoft.com/dotnet/runtime', '10.0', '2026-07-14 02:51:07', 300, NULL, NULL),
(40, 'fac46bff2e02f51425b6e33b0e1169f55dfb053d83511ca28aa50c09fd5ed7a4', 'debian', '13.6', '2026-07-13 02:00:00', 186, NULL, NULL),
(41, '9344f8b8992482f80cba753f323adeaf17690076c095ccff6cc9536be98185dc', 'debian', '12.15', '2026-07-13 02:00:00', 185, NULL, NULL),
(42, '86cc6144ef39bb0fbed2329e1ad79b13ee82e7b2e4739213a0db0800e668a74a', 'mcr.microsoft.com/mssql/server', '2025-latest', '2026-07-09 18:43:23', 2468, NULL, NULL),
(43, '3d0f7584ed7d04e27fa050d6683a74746608faf21f202be78460d679cc56461f', 'postgres', '15.18-alpine3.24', '2026-07-07 19:48:31', 417, NULL, NULL),
(44, '8c185ae01d7a7e910453af189efbf76251740d9b6a149ab68e26e426540fd294', 'python', '3.10.20-alpine3.24', '2026-07-06 23:50:36', 81, NULL, NULL),
(45, '5946476338742b200bb9ff88f8be56275ddae4b3949c72305cb0dbf10cfcb760', 'composer', '2.10.2', '2026-07-06 20:11:00', 315, NULL, NULL),
(46, '79def1d16ece3ab1a6656c46a23bfd80ad33887fbd33626e7bd743cef54ef9c6', 'php', '8.5.8-fpm-alpine3.24', '2026-07-06 18:51:55', 150, NULL, NULL),
(47, '8d7090ce03736b6ecfd739d87a46ab59b5d1d0d837f1ac7c5d2702f1d312f5a0', 'php', '8.5.8-cli-alpine3.24', '2026-07-06 18:51:50', 186, NULL, NULL),
(48, 'a1d9d671994fc2d26e297ac56b4b1522a8bc7fa71c43b14cd1b1fe6c5116f7dc', 'node', '26.4.0-trixie-slim', '2026-06-25 16:50:01', 351, NULL, NULL),
(49, 'a0b9bf06e4e6193cf7a0f58816cc935ff8c2a908f81e6f1a95432d679c54fbfd', 'node', '24.18-alpine3.24', '2026-06-24 20:11:42', 231, NULL, NULL),
(50, 'ad88e1c86cbf12ef52d0a0360cd4b774d22956c5ee9c565645fb019d7aacb6c3', 'mysql', '9.7.1', '2026-06-24 01:34:02', 1311, NULL, NULL),
(51, '5b8f294aff9041b7191c34a4bab3ac270157a28774d4b0660e9743297b697e48', 'mcr.microsoft.com/playwright', 'v1.61.1-noble', '2026-06-23 22:01:45', 3502, NULL, NULL),
(52, 'f239b4819f4dd322d99509f1b5b14f2107bf23857f9ccd3c14333f0928a2bcc6', 'opensuse/leap', '16.0', '2026-06-18 23:54:41', 160, NULL, NULL),
(53, '1b766f17b84026429b7cb243317b142921b24432336e798bc881c43f45ed9567', 'httpd', '2.4.68-alpine3.24', '2026-06-16 02:16:19', 97, NULL, NULL),
(54, '28bd5fe8b56d1bd048e5babf5b10710ebe0bae67db86916198a6eec434943f8b', 'alpine', '3.24', '2026-06-16 02:01:29', 13, NULL, NULL),
(55, 'f5e8002f6cdec21dcd000b23817fd385d4db8234fbbbb54c43c2c173d9fa2d71', 'pandoc/latex', '3.10.0.0-alpine', '2026-06-13 11:01:16', 774, NULL, NULL),
(56, '53958ec7b67c2c9355df922dd08dbf0360611f8c3cdb656875e81873db9ffdba', 'ubuntu', '26.04', '2026-06-10 05:29:33', 160, NULL, NULL),
(57, 'b1c7bf836e64ed9406a8984af29509f40089d55cea14b32f12c4726a1f17104b', 'mariadb', '12.3.2-noble', '2026-06-02 10:19:20', 464, NULL, NULL),
(58, '786a8b558f7be160c6c8c4a54f9a57274f3b4fb1491cf65146521ae77ff1dc54', 'ubuntu', '24.04', '2026-05-20 03:37:22', 119, NULL, NULL),
(59, 'd56a2534ffd262e92c12fd3249d3924d296d97086da773f821d7d0477435ea04', 'oven/bun', '1.3.14-slim', '2026-05-13 05:50:49', 246, NULL, NULL),
(60, 'fd8d9aa63ba2f0982b5304e1ee8d3b90a210bc1ffb5314d980eb6962f1a9715d', 'busybox', '1.38.0', '2026-05-13 04:21:49', 7, NULL, NULL),
(61, '96498ffd522e70807ab6384a5c0485a79b9c7c08ca79ba08623edcad1054e62d', 'hello-world', 'latest', '2026-03-23 22:33:59', 1, NULL, NULL),
(62, '654efe396b7488ae4d815a2a5321b852bd7dd3a22b22717f5319a504dde69c0c', 'idomi27/docs', '26', '2025-07-31 21:43:37', 1157, NULL, NULL),
(63, 'f403f3b5054f8f35ebe8dd167e0c608945a8fd992f3d278d2a8652b58b80dc92', 'node', '24.0.1-bookworm-slim', '2025-05-08 23:34:11', 333, NULL, NULL),
(64, '9532d8c39891ca2ecde4d30d7710e01fb739c87a8b9299685c63704296b16028', 'busybox', '1.37.0', '2024-09-26 23:31:42', 7, NULL, NULL),
(65, '5aaa41f9f45b9af5cd3e694cd4682dfaddb54b894211d3661ddcd0d4267a77ad', 'dockage/mailcatcher', '0.9.0', '2024-05-17 11:52:44', 95, NULL, NULL),
(66, 'a7d4716a71338800c8a3402a91cf5fe963c22efef9fa641d9ca22468d13c5cb4', 'orangeopensource/hurl', '1.8.0', '2022-11-18 13:51:42', 20, NULL, NULL),
(67, 'dae203fe11646a86937bf04db0079adef295f426da68a92b40e3b181f337daa7', 'vulnerables/web-dvwa', 'latest', '2018-10-12 19:49:01', 935, NULL, NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `images`
--
ALTER TABLE `images`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `images`
--
ALTER TABLE `images`
  MODIFY `id` bigint UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=68;
COMMIT;
