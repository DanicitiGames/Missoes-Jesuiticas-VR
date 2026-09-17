# Tekohá Server

O **Tekohá Server** é o backend e servidor de sinalização desenvolvido em Node.js para sustentar o ecossistema do **Projeto Tekohá** — um ambiente virtual imersivo focado no ensino da história das Missões Jesuíticas. 

O servidor é responsável por orquestrar a sinalização WebRTC (Render Streaming), gerenciar dados educacionais e sincronizar a experiência entre aplicações Unity (VR/Desktop) e clientes Web/Mobile.

---

## 📌 Funcionalidades Principais

* **Sinalização WebRTC:** Gerencia a troca de metadados (SDP) e candidatos ICE via WebSocket entre a Unity e os navegadores web.
* **Orquestração de Streaming:** Permite a transmissão de vídeo de alta performance e baixa latência via redes locais, Wi-Fi e redes móveis **5G Privadas**.

---

## 🚀 Pré-requisitos

Antes de iniciar, garanta que você possui os seguintes softwares instalados:

* **Node.js** (v18.x ou superior)
* **npm** ou **yarn**
* **Unity Editor** (com suporte ao pacote *Unity Render Streaming*)

---

## 🔧 Instalação e Configuração

1. **Clone o repositório do projeto Tekohá:**
   ```bash
   git clone https://github.com/DanicitiGames/Missoes-Jesuiticas-VR.git

2. **Entre na pasta do servidor (TekohaServer):** 
    ```bash
    cd TekohaServer

3. **Instale as dependências:**
    ```bash
    npm install

4. **Compile o projeto Typescript:**
    ```bash
    npm run build

## 💻 Executando o Servidor

Para iniciar o servidor de sinalização e servidor web:

    npm start

Após iniciar, o terminal exibirá as portas e endereços IP disponíveis para conexão (IP's abaixo são ilustrativos):

    Use websocket for signaling server ws://191.4.32.236
    start as public mode
    http://191.4.32.236:8080
    http://127.0.0.1:8080

Abra o endereço de IP de sua preferência, na página web clique em ReceiverSample e no botão play

A transmissão será iniciada.
