# CraftOptimizer

**CraftOptimizer** is a Windows Forms application designed to assist *Lost Ark* players in optimizing their crafting of **Oreha Fusion Materials**. By inputting available quantities of base materials and selecting a specific Life Skill (e.g., Excavating), the application calculates the optimal crafting strategy to maximize output, utilizing Google's OR-Tools for linear optimization.

---

## 🔍 Background

In *Lost Ark*, **Oreha Fusion Materials** are essential for Tier 4 gear honing. Players can obtain these materials through:

- **Life Skills**: Gathering resources via activities like Excavating, Hunting, and Fishing.
- **Stronghold Crafting**: Converting gathered materials into fusion materials within the player's stronghold.
- **Market Purchase**: Buying directly from the in-game market, often at a premium.

Efficient crafting requires balancing the use of gathered materials and conversions to maximize output while minimizing resource expenditure.  
(Source: [lostarkcodex.com](https://lostarkcodex.com/us/item/6861012/))

---

## ⚙️ Features

- **Material Input**: Enter quantities for materials such as Ancient Relic, Rare Relic, and Oreha Relic.
- **Life Skill Selection**: Choose from Foraging, Logging, Mining, Hunting, Fishing, or Excavating.
- **Optimization Calculation**: Determine the optimal number of crafts and necessary conversions.
- **Result Display**: View total crafts and breakdown of conversions (e.g., Rare Relic to Oreha Relic).
- **Persistent Settings**: Remembers the last selected Life Skill for user convenience.

---

## 🧮 Optimization Logic

The application employs linear programming to solve the following:

### Variables:
- `crafts`: Number of Oreha Fusion Materials to craft.
- `rare_to_oreha`, `ancient_to_rare`: Quantities of Rare and Ancient Relics converted to higher-tier materials.

### Constraints:
- Ensure available materials (after conversions) meet the requirements for crafting.
- Total materials created (from conversions) plus existing materials must be sufficient for crafting.

### Objective:
- Maximize the number of `crafts` within the given constraints.

---

## 🖥️ User Interface

- **Textboxes**: Input fields for materials like Ancient Relic, Rare Relic, and Oreha Relic.
- **ComboBox**: Dropdown to select the Life Skill type.
- **Labels**: Display results for total crafts and each conversion step.
- **Button**: Initiates the optimization calculation.

---

## 🛠️ Technologies Used

- **C# Windows Forms**: For the graphical user interface.
- **Google OR-Tools**: To perform linear optimization calculations.
- **.NET 8 Runtime**: Required for application execution.

---

## 📦 Installation

1. **Download**:  
   Download the latest `CraftOptimizerInstaller.exe` from the [Releases](https://github.com/kemkum53/LOA_CraftOptimizer/releases) section.

2. **Run Installer**:  
   Execute the downloaded installer and follow the on-screen instructions.

3. **Launch Application**:  
   After installation, launch CraftOptimizer from the desktop shortcut or the Start Menu.

> Note: The installer includes the .NET 8 Runtime. If it’s not already installed, the setup will install it automatically.

---

## 🤝 Contributing

Contributions are welcome! If you have suggestions for improvements or new features, feel free to fork the repository and submit a pull request. Please ensure your code is clean and well-documented.

---

## 📄 License

This project is licensed under the MIT License.  
See the [LICENSE](LICENSE) file for more details.

---

## 📬 Contact

If you encounter issues or have feedback, please open an issue on the [GitHub Issues](https://github.com/kemkum53/LOA_CraftOptimizer/issues) page.

---
