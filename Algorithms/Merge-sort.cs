//Merge-sort algorithm

public static void merge(List<Vector2> L, int p, int q, int r, float xhouse, float yhouse)
{
    List<Vector2> TempL = new List<Vector2>();
    int start = p;
    int start_end = q;
    int middle = q + 1;
    int end = r;
    int position = 0;
    int nr_items = (end - start + 1);
    int count = 0;

    while ((start <= start_end) && (middle <= end))
    {
        count++;
        double dstart = Math.Sqrt((Math.Pow((xhouse - L[start].X), 2) + Math.Pow((yhouse - L[start].Y), 2)));
        double dmiddle = Math.Sqrt((Math.Pow((xhouse - L[middle].X), 2) + Math.Pow((yhouse - L[middle].Y), 2)));
        if (dstart <= dmiddle)
        {
            TempL.Insert(position++, L[start++]);
        }
        else
        {
            TempL.Insert(position++, L[middle++]);
        }
    }
    while (start <= start_end)
    {
        TempL.Insert(position++, L[start++]);
    }

    while (middle <= end)
    {
        TempL.Insert(position++, L[middle++]);
    }

    for (int i = 0; i < nr_items; i++)
    {
        L.RemoveAt(end);
        position--;
        L.Insert(end, TempL[position]);
        end--;
    }
}

public static void merge_sort(List<Vector2> L, int p, int r, float xhouse, float yhouse)
{
    if (p < r)
    {
        int q = (p + r) / 2;
        merge_sort(L, p, q, xhouse, yhouse);
        merge_sort(L, q + 1, r, xhouse, yhouse);
        merge(L, p, q, r, xhouse, yhouse);
    }
}

private static IEnumerable<Vector2> SortSpecialBuildingsByDistance(Vector2 house, IEnumerable<Vector2> specialBuildings)
{
    float xhouse = house.X;
    float yhouse = house.Y;
    List<Vector2> buildingslist = specialBuildings.ToList<Vector2>();

    merge_sort(buildingslist, 0, (buildingslist.Count() - 1), xhouse, yhouse);

    IEnumerable<Vector2> Buildingslist = buildingslist.AsEnumerable<Vector2>();
    return Buildingslist;
}