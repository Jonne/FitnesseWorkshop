package nl.devnology.fitnesse.configuration;

/**
 * @author Erik Pragt
 */
public class ConfigurationTest {
    private String value;

    public void setInput(String input) {
        this.value = input;
    }

    public String output() {
        return value;
    }
}
