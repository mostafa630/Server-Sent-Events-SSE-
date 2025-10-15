# 🧠 Server-Sent Events (SSE) Demo

A simple **.NET** project demonstrating **real-time one-way communication** from the **server to the client** using **Server-Sent Events (SSE)**.

---

## 📦 Project Structure
ShortPollingModel/  
│  
├── Server/ → Minimal API backend simulating job creation & progress updates  
└── Client/ → Html page that cat as SSE client  


---

## ⚙️ How It Works

1. **Client** opens a persistent connection to: Get/events  using the browser’s built-in **EventSource API**.

2. **Server** keeps the connection open and periodically sends messages to the client.

3. **Client** automatically receives messages in real time — **no need for polling**.

4. If the connection drops, the **EventSource** automatically **reconnects**.

---

## 🧰 Tech Stack

- **.NET 9**
- **Minimal API** (for backend)
- **HTML + JavaScript (EventSource API)**
- **CORS for cross-origin streaming**

---

## 🚀 How to Run

### 1️⃣ Run the Server
```bash
cd Server
dotnet run
```
### 2️⃣ Run the Client : open the HTML Page on the Browser


## 🚀 Example

Start Server and Open the HTMl Page on the browser : 
<img width="1907" height="364" alt="image" src="https://github.com/user-attachments/assets/1839f167-91ff-4723-bd3b-21dcfe927207" />
Server still sending Notifications : 
<img width="1904" height="965" alt="image" src="https://github.com/user-attachments/assets/7ef5c1c2-18d4-46e6-8486-9ef19e51d992" />

stream ended only  when the Server is down or client disconnect.
