# VRSignify

**VRSignify** is a Unity-based application developed for the **Meta Quest 3**. It leverages the Hand Tracking API to translate American Sign Language (ASL) into text in real-time. This project was created as part of **NatHacks 2024**, showcasing the potential of VR for enhancing communication and accessibility.

---

## 🎯 **Features**

- **Real-time ASL Recognition**: Translates American Sign Language gestures into text using Meta Quest 3's Hand Tracking API.
- **Interactive VR Environment**: Provides an immersive platform for practicing and learning ASL.

---

## 🚀 **Getting Started**

### Prerequisites

- Unity (version 2022.3 or later recommended)
- Meta Quest 3 headset
- [Meta XR Plugin](https://developer.meta.com/downloads) for Unity
- Basic knowledge of Unity development

---

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/hojats7731/VRSignify.git
   ```
2.  Open the project in Unity:

-  Launch Unity Hub.
-  Click **Open** and select the VRSignify project folder.

3.  Install required Unity packages:

-  Go to **Window > Package Manager**.
-  Add **Meta XR Plugin** and **Hand Tracking Support**.

4.  Connect your Meta Quest 3:

-  Enable **Developer Mode** on your Quest.
-  Connect the device to your PC via USB.
-  Ensure Unity recognizes your Quest in **Build Settings**.

---

**Usage**

1.  Build and run the app on your Meta Quest 3.

2.  Use hand gestures to perform ASL signs.

3.  View the real-time translations within the VR environment.

---

**🛠 Development**

**Hand Tracking Integration**

This project utilizes Meta's Hand Tracking API for detecting and classifying hand gestures. A custom-trained machine learning model ensures high accuracy for ASL interpretation.

**Project Structure**

-  **Assets/**: Unity assets, including scripts, models, and prefabs.
-  **Scripts/**: Core C# scripts for hand tracking, gesture recognition, and UI management.
-  **Models/**: 3D models for the VR environment.
-  **Plugins/**: Meta XR Plugin and related dependencies.

---

**🤝 Contributing**

We welcome contributions to make **VRSignify** even better! Here's how you can contribute:

1.  Fork the repository.

2.  Create a new branch for your feature or bugfix:

```bash
git checkout -b feature-name
```

3.  Commit your changes and push them to your branch:

```bash
git commit -m "Add feature name"
git push origin feature-name
```

4.  Open a pull request and describe your changes.

---

**🌟 Acknowledgments**

-  **NatHacks 2024**: This project was built during NatHacks 2024.

-  **Meta Hand Tracking API**: For enabling robust and precise hand tracking.

-  **Unity Community**: For their incredible resources and support.

-  All contributors who helped make **VRSignify** a reality!
