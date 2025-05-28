# Parking Management Experiment 🚗💻

*A practical exploration of cost-effective software solutions for small parking lot operators*

> This isn't production-grade software, but rather a experiment of how to make pragmatic technical choices for very small businesses.

## Why I Built This

I built this project as a quick prototype to explore how to deliver a practical, low-cost parking management system for small operators who want to avoid expensive software subscriptions and complicated setups.

## Objective

This project simulates what I would recommend if hired by a small parking lot owner needing basic management software with:

- **Minimal budget** (under $1,000 total cost)  
- **Low-tech operation** (runs on existing hardware)  
- **Zero recurring fees** (no cloud dependencies)  

## Solution Overview

| Component       | Choice          | Rationale                                              |
|-----------------|-----------------|-------------------------------------------------------|
| **Database**    | PostgreSQL      | Free, reliable, and lightweight (runs on <1GB RAM)    |
| **Backend**     | .NET Core + EF  | Rapid development with strong data integrity          |
| **Frontend**    | Svelte          | Tiny footprint (works on old browsers)                 |

### Key Features

- Vehicle entry/exit registration  
- Automated fee calculation  
- Local data persistence (no internet required)  
- Simple user interface  

## Technical Considerations

**Why not...**

- **Excel?** Prone to human error and version control issues  
- **Pure JS app?** localStorage isn't reliable for business data  
- **Commercial software?** Overkill for small lots (typically $200+/month)  

**Trade-offs made:**

- Uses more memory than SQLite but gains proper DB features  
- Requires .NET runtime but gets EF's productivity benefits  
- Svelte has smaller ecosystem than React but much smaller footprint  


## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
