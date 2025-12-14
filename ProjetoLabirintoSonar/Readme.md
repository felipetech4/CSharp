# 🎮 Jogo de Exploração no Escuro (Console)

Este projeto é um **jogo em modo console**, desenvolvido em **C#**, onde o jogador precisa encontrar a saída de um labirinto escuro antes que a bateria da lanterna acabe ou que um monstro o encontre.

## 🧠 Objetivo do Jogo

- Encontrar a **saída** do mapa.
- Evitar o **monstro**.
- Gerenciar a **bateria da lanterna**, que diminui a cada movimento.

O jogo termina quando:
- ✅ O jogador encontra a saída  
- ❌ O monstro alcança o jogador  
- 🔋 A bateria chega a zero  

---

## 🗺️ Funcionamento do Mapa

- O mapa é um **grid 10x10**.
- O jogador, o monstro e a saída são posicionados **aleatoriamente**.
- Nenhuma posição inicial se sobrepõe.

---

## 🎮 Controles

Use as teclas abaixo para se movimentar:

| Tecla | Movimento |
|------|-----------|
| W | Cima |
| A | Esquerda |
| S | Baixo |
| D | Direita |

- Movimentos inválidos (parede) não consomem bateria.
- Cada movimento válido consome **1 ponto de bateria**.

---

## 📡 Sistema de Sensores (Dicas)

O jogo possui um sistema de “sonar” que ajuda o jogador:

### Saída
- 🔊 **Apito rápido**: saída muito próxima (≤ 2 de distância)
- 🔈 **Apito lento**: saída relativamente próxima (≤ 5 de distância)

### Monstro
- 👃 **Cheiro podre muito forte**: monstro a 1 de distância

---

## 👾 Monstro

- O monstro se move **aleatoriamente** a cada turno.
- Se o monstro alcançar o jogador, o jogo acaba.

---

## 🔋 Bateria

- A bateria inicia com **20 unidades**.
- Cada movimento válido do jogador reduz a bateria.
- Se a bateria chegar a **0**, o jogador perde.

---

## 🛠️ Tecnologias Utilizadas

- Linguagem: **C#**
- Plataforma: **.NET (Console Application)**

---

## ▶️ Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git
