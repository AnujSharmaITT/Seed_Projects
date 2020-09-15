
package com.itt.mock;

import org.springframework.core.io.ClassPathResource;
import org.springframework.core.io.Resource;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;

/**
 * This class is reponsibel for loading the files from the src/main/resources
 * folder.
 * 
 * @author Rakesh Sawan
 */
public final class ResourceFileLoader {

    /**
     * Prevent creation of object for this class.
     */
    private ResourceFileLoader() {
    }

    /**
     * Loads a file from resources folder.
     * 
     * @param fileName Name of the file
     * @return contents of the resource being loaded
     */
    public static String loadResource(final String fileName) {

        Resource resource = new ClassPathResource(fileName);
        StringBuffer data = new StringBuffer();
        try {
            InputStream is = resource.getInputStream();
            BufferedReader br = new BufferedReader(new InputStreamReader(is));
            String line;
            while ((line = br.readLine()) != null) {
                data.append(line);
                data.append("\n");
            }
            br.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return data.toString();

    }

}
