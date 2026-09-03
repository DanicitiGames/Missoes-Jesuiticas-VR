# Tekohá Server 🏛️ VR & Streaming Server

O **Tekohá Server** é o backend e servidor de sinalização desenvolvido em Node.js para sustentar o ecossistema do **Projeto Tekohá** — um ambiente virtual imersivo focado no ensino da história das Missões Jesuíticas. 

O servidor é responsável por orquestrar a sinalização WebRTC (Render Streaming), gerenciar dados educacionais e sincronizar a experiência entre aplicações Unity (VR/Desktop) e clientes Web/Mobile.

---

## 📌 Funcionalidades Principais

* **Sinalização WebRTC:** Gerencia a troca de metadados (SDP) e candidatos ICE via WebSocket entre a Unity e os navegadores web.
* **Orquestração de Streaming:** Permite a transmissão de vídeo de alta performance e baixa latência via redes locais, Wi-Fi e redes móveis **5G Privadas**.
* **Suporte Multiplataforma:** Atua como o ponto de encontro central para clientes acessando via navegadores em dispositivos móveis, tablets ou óculos de RV.

---

## 🚀 Pré-requisitos

Antes de iniciar, garanta que você possui os seguintes softwares instalados:

* **Node.js** (v18.x ou superior)
* **npm** ou **yarn**
* **Unity Editor** (com suporte ao pacote *Unity Render Streaming*)

---

## 🔧 Instalação e Configuração

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/DanicitiGames/Missoes-Jesuiticas-VR.git
   cd TekohaServer
   ``` 
2. **Instale as dependências:**
   ```bash
   npm install
   ``` 

3. **Compile o projeto TypeScript:**
   ```bash
   npm run build
   ``` 

## 💻 Executando o Servidor

Para iniciar o servidor de sinalização e servidor web:
   ```bash
   npm start
   ``` 

Após iniciar, o terminal exibirá as portas e endereços IP disponíveis para conexão:
   ```
   Use websocket for signaling server ws://192.168.15.23
   start as public mode
   http://192.168.15.23:80
   http://127.0.0.1:80
   ``` 

Ao abrir a página do Unity Render Streaming Samples no IP disponível, clique em Receiver Sample.